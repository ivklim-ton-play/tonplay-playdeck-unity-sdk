using System.Collections.Generic;
using Proyecto26;
using RSG;

namespace TONPlay {
    public partial class PlayDeckAPI {
        private const string PATH_GET_DATA = "/api/v1/cloudsave/";

        /// <summary>
        /// Get game data
        /// </summary>
        public IPromise<Data> GetData(string key) {
            RequestHelper requestOptions = null;

            requestOptions = new RequestHelper {
                Uri = SERVER + PATH_GET_DATA + key,
                Headers = new Dictionary<string, string> {
                    { AUTHORIZATION, $"Bearer " + XAuthToken }
                }
            };

            AddDefaultRequestOptions(requestOptions);

            return RestClient.Get<Data>(requestOptions);
        }
    }
}
