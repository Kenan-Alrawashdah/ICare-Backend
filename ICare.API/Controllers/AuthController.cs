using ICare.Core.ApiDTO;
using ICare.Core.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ICare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly IFileService _fileService;
        private readonly IPasswordHashingService _passwordHashingService;
        private readonly ITokenService _tokenService;
        private readonly IResetPasswordServices _resetPasswordServices;

        public AuthController(IUserServices userServices, IFileService fileService, IPasswordHashingService passwordHashingService, ITokenService jWTService, IResetPasswordServices resetPasswordServices)
        {
            this._userServices = userServices;
            this._fileService = fileService;
            this._passwordHashingService = passwordHashingService;
            this._tokenService = jWTService;
            this._resetPasswordServices = resetPasswordServices;
        }

        /// <summary>
        /// SignUp Page for Patient
        /// </summary>
        /// <param name="request"></param>
        /// <returns>token</returns>
        [HttpPost]
        [Route("PatientRegistration")]
        public ActionResult<ApiResponse<RegistrationApiDTO.Response>> PatientRegistration(RegistrationApiDTO.Request request)
        {


            var response = new ApiResponse<RegistrationApiDTO.Response>();
            if (_userServices.CheckEmailExist(request.Email))
            {
                response.AddError("The email is already exist");
                return Ok(response);
            }
            var hashedPassword = _passwordHashingService.GetHash(request.Password);
            var passwordForLogin = request.Password;
            request.Password = hashedPassword;
            _userServices.Registration(request);
            //TODO: Return the Token
            var login = new LoginApiDTO.Request()
            {
                Email = request.Email,
                Password = passwordForLogin
            };
            string refreshtoken;
            var token = _tokenService.AuthAndGetToken(login, out refreshtoken);
            response.Data = new RegistrationApiDTO.Response();
            response.Data.AccessToken = token;
            response.Data.RefreshToken = refreshtoken;
            return Ok(response);
        }

    }
}
