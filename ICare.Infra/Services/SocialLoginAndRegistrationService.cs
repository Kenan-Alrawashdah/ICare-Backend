using ICare.Core.ApiDTO;
using ICare.Core.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ICare.Infra.Services
{
    public class SocialLoginAndRegistrationService : ISocialLoginAndRegistrationService
    {
        private readonly IUserServices _userServices;
        private readonly IPasswordHashingService _passwordHashingService;
        private readonly IResetPasswordServices _resetPasswordServices;
        private readonly ITokenService _tokenService;

        public SocialLoginAndRegistrationService(IUserServices userServices , IPasswordHashingService passwordHashingService, IResetPasswordServices resetPasswordServices, ITokenService tokenService)
        {
            this._userServices = userServices;
            this._passwordHashingService = passwordHashingService;
            this._resetPasswordServices = resetPasswordServices;
            this._tokenService = tokenService;
        }
        public async Task<RegistrationApiDTO.Response> LoginAndRegistrationUsingSocial(RegistrationApiDTO.Request request)
        {

            var user = _userServices.GetUserByEmail(request.Email);
            var password = _resetPasswordServices.CreateRandomPassword(9);

            if (user == null)
            {
                var hashedPassword = _passwordHashingService.GetHash(password);
                request.Password = hashedPassword;
                request.PhoneNumber = "";
                _userServices.Registration(request);

                string refreshToken;
                var result = new RegistrationApiDTO.Response();
                var LoginModel = new LoginApiDTO.Request()
                {
                    Email = request.Email,
                    Password = password
                };
                result.AccessToken = _tokenService.AuthAndGetToken(LoginModel, out refreshToken);
                result.RefreshToken = refreshToken;
                return result;
            }
            else
            {

                var result = new RegistrationApiDTO.Response();
                result.AccessToken = _tokenService.GenerateAccessToken(user.FirstName, "Patient", user.Email);
                result.RefreshToken = _tokenService.GenerateRefreshToken(user.Id);
                return result;
            }


        }
    }
}
