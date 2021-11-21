using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Strava.Athletes;

namespace HomiePages.Application.Dtos.Strava
{
    public class StravaTokenModel
    {
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
        [JsonProperty("expires_at")]
        public long ExpiresAtTicks { get; set; }

        [JsonProperty("expires_in")]
        public long ExpiresInTicks { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("athlete")]
        public Athlete Athlete { get; set; }
    }
}
