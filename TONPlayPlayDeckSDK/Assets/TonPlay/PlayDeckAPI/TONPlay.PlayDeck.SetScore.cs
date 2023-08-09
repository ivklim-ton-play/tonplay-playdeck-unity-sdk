using System.Collections.Generic;
using Proyecto26;
using RSG;
using UnityEngine;

namespace TONPlay {
    public partial class PlayDeckAPI {
        private const string PATH_SET_SCORE = "/api/v1/score/";

        /// <summary>
        /// Set game score
        /// </summary>
        /// <param name="force">Can override score to less value if true</param>
        public IPromise<Score> SetScore(ulong score, bool force = false) {
            RequestHelper requestOptions = null;

            var paramsList = new Dictionary<string, string> {
                    { "force", force.ToString() },
                };

            requestOptions = new RequestHelper {
                Uri = SERVER + PATH_SET_SCORE + score.ToString(),
                Headers = new Dictionary<string, string> {
                    { AUTHORIZATION, $"Bearer " + XAuthToken }
                },
                Params = paramsList,

            };

            AddDefaultRequestOptions(requestOptions);

            return RestClient.Put<Score>(requestOptions);
        }
    }
}
