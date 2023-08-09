using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TONPlay {
    public partial class PlayDeckAPI : BaseAPI {
        public const string AUTHORIZATION = "Authorization";
        public const string SERVER = "https://api.playdeck.fantasylabsgames.dev";
        public string XAuthToken { get; set; }
    }
}