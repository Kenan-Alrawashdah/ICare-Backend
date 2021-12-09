using ICare.Core.ApiDTO;
using ICare.Core.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICare.API.Controllers
{

    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUserServices _userServices;
        private readonly IRefreshTokenServices _refreshTokenServices;

        public TokenController(ITokenService tokenService,IUserServices userServices,IRefreshTokenServices refreshTokenServices)
        {
            this._tokenService = tokenService;
            this._userServices = userServices;
            this._refreshTokenServices = refreshTokenServices;
        }

        /// <summary>
        /// Issue a new access token
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Refresh")]
        public async Task<ActionResult<ApiResponse<TokenApiModel.Response>>> Refresh(TokenApiModel.Request model)
        {
            var princibles = _tokenService.GetClaimsFromExpiredToken(model.AccessToken);

            var user = _userServices.GetUser(princibles);

            if (user == null)
            {
                return BadRequest("Invaled Access Token");
            }

            var refreshToken = await _refreshTokenServices.GetRefreshTokenByUserId(user.Id);

            if (model.RefreshToken != refreshToken.RToken)
            {
                return BadRequest("Invaled Refresh Token");
            }

            var response = new ApiResponse<TokenApiModel.Response>();

            string refToken; 
            response.Data = new TokenApiModel.Response();
            response.Data.AccessToken = _tokenService.GenerateAccessTokenWithClaims(princibles,out refToken);
            response.Data.RefreshToken = refToken;




            return Ok(response);
        }

        /// <summary>
        /// Delete the current refresh token of the current user
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("Revoke")]
        [Authorize]
        public async Task<ApiResponse> Revoke()
        {
            // var user = await _userManager.GetUserAsync(User);
            // user.RefreshToken = null;
            //await _userManager.UpdateAsync(user);
            return new ApiResponse();
        }
    }
}
