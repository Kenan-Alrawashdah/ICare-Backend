using ICare.Core.ApiDTO;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace ICare.Core.IServices
{
    public interface ITokenService
    {
        string AuthAndGetToken(LoginApiDTO.Request loginDTO, out string refreshToken);
        string GenerateAccessToken(string firstName, string role, string email);
        string GenerateAccessTokenUsingClaims(ClaimsPrincipal claims, out string refreshToken);
        string GenerateRefreshToken(int userId);
        ClaimsPrincipal GetClaimsFromExpiredToken(string token);
    }
}
