using ICare.Core.ApiDTO;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace ICare.Core.IServices
{
    public interface ITokenService
    {
        string GenerateAccessToken(LoginApiDTO.Request loginDTO, out string refreshToken);
        string GenerateAccessTokenWithClaims(ClaimsPrincipal claims, out string refreshToken);
        ClaimsPrincipal GetClaimsFromExpiredToken(string token);
    }
}
