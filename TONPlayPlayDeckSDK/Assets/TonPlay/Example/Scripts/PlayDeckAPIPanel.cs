using System.Collections;
using System.Collections.Generic;
using Proyecto26;
using UnityEngine;
using UnityEngine.UI;

namespace TONPlay.Example {
    public class PlayDeckAPIController : MonoBehaviour {

        [TextArea]
        [SerializeField]
        private string _token;

        [SerializeField]
        private InputField _scoreInputField;

        [SerializeField]
        private InputField _keyDataInputField;
        [SerializeField]
        private InputField _dataInputField;

        private PlayDeckAPI _playDeckAPI;
        private string _userJWTString;
        private UserJWT _userJWT;


        public void GetScore() {
            _playDeckAPI.GetScore().Then(response => {
                _scoreInputField.text = response.score.ToString();
            }).Catch(err => {
                var error = err as RequestException;
                Debug.LogError("Error response:" + error.Message);
            });
        }

        public void SetScore() {
            ulong score;
            if (!ulong.TryParse(_scoreInputField.text, out score)) {
                _scoreInputField.text = "";
                _scoreInputField.placeholder.GetComponent<Text>().text = "Please, enter correct score";
                return;
            }

            _playDeckAPI.SetScore(score, true).Then(responce => {
                Debug.Log($"New value {score} has set");
            }).Catch(err => {
                var error = err as RequestException;
                Debug.LogError("Error response:" + error.Message);
            });
        }

        public void GetData() {
            _playDeckAPI.GetData(_keyDataInputField.text).Then(responce => {
                _dataInputField.text = responce.data;
            }).Catch(err => {
                var error = err as RequestException;
                Debug.LogError("Error response:" + error.Message);
            });
        }

        public void SetData() {
            Data data = new Data() {
                key = _keyDataInputField.text,
                data = _dataInputField.text
            };

            _playDeckAPI.SetData(data);
        }

        private void Start() {
            GetUserJWT();
            CheckAllRequiredData();
            _userJWT = JsonUtility.FromJson<UserJWT>(_userJWTString);

            _playDeckAPI = new PlayDeckAPI();
            _playDeckAPI.XAuthToken = _token;
        }

        private void GetUserJWT() {
            string _queryToken = QueryParams.TOKEN;
            //your address can be like https://yourgame.com?token=yourTokenFromTONPlayOrYourTelegramBot
            string uri = Application.absoluteURL;
            Dictionary<string, string> query = ParamParse.GetBrowserParameters(uri);

            string token = query.ContainsKey(_queryToken) ? query[_queryToken] : _token;
            _userJWTString = DecoderJWT.Decode(token);
        }

        private bool CheckAllRequiredData() {
            bool isValid = true;

            if (string.IsNullOrEmpty(_token)) {
                Debug.LogError("Please enter your token to _token");
                isValid = false;
            }

            return isValid;
        }

    }
}
