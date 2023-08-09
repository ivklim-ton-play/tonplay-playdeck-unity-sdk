using System.Collections.Generic;
using Proyecto26;
using RSG;

namespace TONPlay {
    public partial class PlayDeckAPI {
        private const string PATH_SET_DATA = "/api/v1/cloudsave";

        /// <summary>
        /// Set game data
        /// </summary>
        public IPromise<Data> SetData(Data data) {
            RequestHelper requestOptions = null;

            requestOptions = new RequestHelper {
                Uri = SERVER + PATH_SET_DATA,
                Headers = new Dictionary<string, string> {
                    { AUTHORIZATION, $"Bearer " + XAuthToken }
                },
                Body = data
            };

            AddDefaultRequestOptions(requestOptions);

            return RestClient.Post<Data>(requestOptions);
        }
    }
}
