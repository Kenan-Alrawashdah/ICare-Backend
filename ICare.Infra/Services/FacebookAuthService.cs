using ICare.Core.ApiDTO;
using ICare.Core.IServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ICare.Infra.Services
{
    public class FacebookAuthService : IFacebookAuthService
    {
        private const string TokenValidationUrl = "https://graph.facebook.com/debug_token?input_token={0}&access_token={1}|{2}";
        private const string UserInfoUrl = "https://graph.facebook.com/me?fields=first_name,last_name,picture&access_token={0}";
        private readonly FacebookAuthSettingsService _facebookAuthSettings;
        private readonly IHttpClientFactory _httpClientFactory;
        public FacebookAuthService(FacebookAuthSettingsService facebookAuthSettingsService, IHttpClientFactory httpClientFactory)
        {
            this._facebookAuthSettings = facebookAuthSettingsService;
            this._httpClientFactory = httpClientFactory;
        }
        public async Task<FacebookUserInfoResultDTO> GetUserInfoAsync(string accressToken)
        {

            var formattedUrl = string.Format(UserInfoUrl, accressToken);
            var result = await _httpClientFactory.CreateClient().GetAsync(formattedUrl);
            result.EnsureSuccessStatusCode();
            var responseAsString = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<FacebookUserInfoResultDTO>(responseAsString);
        } 

        public async Task<FacebookTokenValidationResultDTO> ValidateAccressTokenAsync(string accressToken)
        {
            var formattedUrl = string.Format(TokenValidationUrl, accressToken, _facebookAuthSettings.AppId, _facebookAuthSettings.AppSecret);
            var result = await _httpClientFactory.CreateClient().GetAsync(formattedUrl);
            result.EnsureSuccessStatusCode();
            var responseAsString = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<FacebookTokenValidationResultDTO>(responseAsString);
        }
    }
}
