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
        private readonly IJWTService _jWTService;

        public LoginController(IJWTService jWTService)
        {
            this._jWTService = jWTService;
        }

        [HttpPost]
        [Route("SignIn")]
        public ActionResult<ApiResponse<LoginApiDTO.Response>> SignIn(LoginApiDTO.Request requestLoginDTO)
        {
            var response = new ApiResponse<LoginApiDTO.Response>();
            var token = _jWTService.Auth(requestLoginDTO);
            if (token == null)
            {
                response.AddError("Email and password does not match");
                return Ok(response);
            }
            response.Data = new LoginApiDTO.Response();
            response.Data.Token = token;

            return Ok(response);
            
        }
    }
}
