using ICare.Core.ApiDTO;
using ICare.Core.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ICare.Infra.Services
{
    public class FacebookService : IFacebookService
    {
        private readonly IUserServices _userServices;
        private readonly IFacebookAuthService _facebookAuthService;
        private readonly IPasswordHashingService _passwordHashingService;
        private readonly IResetPasswordServices _resetPasswordServices;
        private readonly ITokenService _tokenService;

        public FacebookService(IUserServices userServices,IFacebookAuthService facebookAuthService, IPasswordHashingService passwordHashingService,IResetPasswordServices resetPasswordServices,ITokenService tokenService)
        {
            this._userServices = userServices;
            this._facebookAuthService = facebookAuthService;
            this._passwordHashingService = passwordHashingService;
            this._resetPasswordServices = resetPasswordServices;
            this._tokenService = tokenService;
        }


        public async Task<LoginApiDTO.Response> LoginWithFacebookAsync(string accessToken)
        {
            await _facebookAuthService.ValidateAccressTokenAsync(accessToken);

            var userInfo = await _facebookAuthService.GetUserInfoAsync(accessToken);
            var user = _userServices.GetUserByEmail(userInfo.Email);
            var password = _resetPasswordServices.CreateRandomPassword(9);

            if (user == null)
            {
                var hashedPassword = _passwordHashingService.GetHash(password);

                RegistrationApiDTO.Request request = new RegistrationApiDTO.Request()
                {
                    Email = userInfo.Email,
                    FirstName = userInfo.FirstName,
                    LastName = userInfo.LastName,
                    PhoneNumber = "",
                    Password = hashedPassword
                };

                _userServices.Registration(request);

                string refreshToken;
                var result = new LoginApiDTO.Response();
                var LoginModel = new LoginApiDTO.Request()
                {
                    Email = userInfo.Email,
                    Password = password
                };
                result.AccessToken = _tokenService.AuthAndGetToken(LoginModel, out refreshToken);
                result.RefreshToken = refreshToken;
                return result;
            }
            else
            {
                
                var result = new LoginApiDTO.Response();
                result.AccessToken = _tokenService.GenerateAccessToken(user.FirstName,"Patient",user.Email);
                result.RefreshToken = _tokenService.GenerateRefreshToken(user.Id);
                return result;
            }

            
        }
    }
}
