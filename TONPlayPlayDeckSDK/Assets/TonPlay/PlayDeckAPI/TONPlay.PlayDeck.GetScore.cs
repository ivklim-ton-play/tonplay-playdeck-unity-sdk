using System.Collections.Generic;
using Proyecto26;
using RSG;

namespace TONPlay {
    public partial class PlayDeckAPI {
        private const string PATH_GET_SCORE = "/api/v1/score";

        /// <summary>
        /// Get game score
        /// </summary>
        public IPromise<Score> GetScore() {
            RequestHelper requestOptions = null;

            requestOptions = new RequestHelper {
                Uri = SERVER + PATH_GET_SCORE,
                Headers = new Dictionary<string, string> {
                    { AUTHORIZATION, $"Bearer " + XAuthToken }
                }
            };

            AddDefaultRequestOptions(requestOptions);

            return RestClient.Get<Score>(requestOptions);
        }
    }
}
