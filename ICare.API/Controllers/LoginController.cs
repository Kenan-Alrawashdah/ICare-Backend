using ICare.Core.ApiDTO;
using ICare.Core.DTO;
using ICare.Core.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class LoginController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUserServices _userServices;

        public LoginController(ITokenService tokenService,IUserServices userServices)
        {
            this._tokenService = tokenService;
            this._userServices = userServices;
        }

        [HttpPost]
        [Route("SignIn")]
        public ActionResult<ApiResponse<LoginApiDTO.Response>> SignIn(LoginApiDTO.Request requestLoginDTO)
        {
            var response = new ApiResponse<LoginApiDTO.Response>();
            string refreshToken;
            var token = _tokenService.AuthAndGetToken(requestLoginDTO, out refreshToken);
            if (token == null)
            {
                response.AddError("Email and password does not match");
                return Ok(response);
            }
            response.Data = new LoginApiDTO.Response();
            response.Data.AccessToken = token;
            response.Data.RefreshToken = refreshToken;

            return Ok(response);
            
        }
    }
}
