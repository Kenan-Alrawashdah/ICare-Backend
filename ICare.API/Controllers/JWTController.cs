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
    public class JWTController : ControllerBase
    {
        private readonly IJWTService _jWTService;

        public JWTController(IJWTService jWTService)
        {
            this._jWTService = jWTService;
        }

        [HttpPost]
        [Route("Auth")]
        public IActionResult Auth(RequestLoginDTO requestLoginDTO)
        {
            var result = _jWTService.Auth(requestLoginDTO);
            if (result == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(result);
            }
        }
    }
}
