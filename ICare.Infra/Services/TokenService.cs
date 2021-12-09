using ICare.Core.Data;
using ICare.Core.IServices;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ICare.Core.IRepository;
using ICare.Core.ApiDTO;
using ICare.Core.DTO;

namespace ICare.Infra.Services
{
    public class TokenService : ITokenService
    {
        
        private  JwtOptions _jwtOptions = new JwtOptions();
        private readonly IJWTRepository _jWTRepository;
        private readonly IRefreshTokenServices _refreshTokenServices;
        private readonly IUserServices _userServices;
        private readonly IResetPasswordServices resetPasswordServices;

        public TokenService(IJWTRepository jWTRepository,IRefreshTokenServices refreshTokenServices,IUserServices userServices,IResetPasswordServices resetPasswordServices)
        {
            this._jWTRepository = jWTRepository;
            this._refreshTokenServices = refreshTokenServices;
            this._userServices = userServices;
            this.resetPasswordServices = resetPasswordServices;
        }


        public string GenerateAccessToken(LoginApiDTO.Request loginDTO, out string refreshToken)
        {
            var result = _jWTRepository.Authentication(loginDTO);
            if (result == null)
            {
                refreshToken = null;
                return null;
            }
            else
            {
            //1- token handler : generate token
            var tokenHandler = new JwtSecurityTokenHandler();

            //2- token key : to encode data to token (secure value)
            var tokenKey = Encoding.ASCII.GetBytes("superSecretKey@345");

            //3- token descriptor :( userName , roleNoleName) + expire == session timeout + sign credential == Hmacsha256signtre (method) 
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                //userName, roleName
                Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, result.FirstName),
                    new Claim(ClaimTypes.Role, result.RoleName),
                    new Claim(ClaimTypes.Email , result.Email)
                   }),

                //expire == session timeout
                Expires = DateTime.UtcNow.AddSeconds(20),

                //signcredintial ==(to assgin which encoding method to use) "Hmacsha256signutre"(method used to encode data)
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256)

            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            refreshToken =  GenerateRefreshToken(result.Id);
            return tokenHandler.WriteToken(token);
            }
        }
        public string GenerateAccessTokenWithClaims(ClaimsPrincipal claims, out string refreshToken)
        {
            

            var result = new ResponseLoginDTO
            {
                Email = claims.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value,
                FirstName = claims.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")?.Value,
                RoleName = claims.Claims.FirstOrDefault(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role")?.Value,
               
        };
            if (result.Email == null)
            {
                refreshToken = null;
                return null;
            }
            else
            {
                 var user = _userServices.GetUserByEmail(result.Email);
                if(user == null)
                {
                    refreshToken = null;
                    return null;
                }
                //1- token handler : generate token
                var tokenHandler = new JwtSecurityTokenHandler();

                //2- token key : to encode data to token (secure value)
                var tokenKey = Encoding.ASCII.GetBytes("superSecretKey@345");

                //3- token descriptor :( userName , roleNoleName) + expire == session timeout + sign credential == Hmacsha256signtre (method) 
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    //userName, roleName
                    Subject = new ClaimsIdentity(new Claim[]
                        {
                    new Claim(ClaimTypes.Name, result.FirstName),
                    new Claim(ClaimTypes.Role, result.RoleName),
                    new Claim(ClaimTypes.Email , result.Email)
                       }),

                    //expire == session timeout
                    Expires = DateTime.UtcNow.AddSeconds(20),

                    //signcredintial ==(to assgin which encoding method to use) "Hmacsha256signutre"(method used to encode data)
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256)

                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                refreshToken = GenerateRefreshToken(user.Id);
                return tokenHandler.WriteToken(token);
            }
        }

        private string GenerateRefreshToken(int userid)
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                var refreshToken = Convert.ToBase64String(randomNumber);
                var model = new RefreshToken
                {
                    UserId = userid,
                    RToken = refreshToken
                };
                 _refreshTokenServices.AddRefreshToken(model);

                return refreshToken;
                
            }

        }

        public ClaimsPrincipal GetClaimsFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,

                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key))
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                //throw new SecurityTokenException("Invalid token");
                return null;

            return principal;
        }
    }
}
