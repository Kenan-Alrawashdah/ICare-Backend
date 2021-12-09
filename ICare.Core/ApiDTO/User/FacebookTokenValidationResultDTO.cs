using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.ApiDTO
{
    public class FacebookTokenValidationResultDTO
    {
            [JsonProperty("date")]
            public FacebookTokenValidationData Date { get; set; }
    }
    public class FacebookTokenValidationData
    {
            [JsonProperty("app_id")]
            public string AppId { get; set; }
            [JsonProperty("type")]
            public string Type { get; set; }
            [JsonProperty("application")]
            public string Application { get; set; }
            [JsonProperty("data_access_expires_At")]
            public long DataAccessExpiresAt { get; set; }
            [JsonProperty("expires_At")]
            public long ExpiresAt { get; set; }
            [JsonProperty("is_valid")]
            public bool IsValid { get; set; }
            [JsonProperty("scopes")]
            public string[] Scopes { get; set; }
            [JsonProperty("user_id")]
            public string UserId { get; set; }
        }
   
}
