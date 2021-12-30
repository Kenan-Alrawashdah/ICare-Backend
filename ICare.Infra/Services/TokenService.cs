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
        
        private readonly JwtOptions _jwtOptions = new JwtOptions();
        private readonly IAuthService _authService;
        private readonly IRefreshTokenServices _refreshTokenServices;
        private readonly IUserServices _userServices;

        public TokenService(IAuthService authRespository, IRefreshTokenServices refreshTokenServices,IUserServices userServices)
        {
            this._authService = authRespository;
            this._refreshTokenServices = refreshTokenServices;
            this._userServices = userServices;
        }


        public string AuthAndGetToken(LoginApiDTO.Request loginDTO, out string refreshToken)
        {
            var result = _authService.Authentication(loginDTO);
            if (result == null)
            {
                refreshToken = null;
                return null;
            }
            else
            {
                var token = GenerateAccessToken(result.FirstName, result.RoleName, result.Email);
                refreshToken = GenerateRefreshToken(result.Id);
                return token;
            }
        }

        public string GenerateAccessTokenUsingClaims(ClaimsPrincipal claims, out string refreshToken)
        {
            var email = claims.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            
            var r = _authService.Authentication(email);
            
            var result = new ResponseLoginDTO
            {
                Email = r.Email,
                FirstName = r.FirstName,
                RoleName =  r.RoleName
               
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
                var token = GenerateAccessToken(result.FirstName, result.RoleName, result.Email);
                refreshToken = GenerateRefreshToken(user.Id);
                return token;
            }
        }

        public string GenerateAccessToken(string firstName, string role,string email)
        {
            //1- token handler : generate token
            var tokenHandler = new JwtSecurityTokenHandler();

            //2- token key : to encode data to token (secure value)
            var tokenKey = Encoding.ASCII.GetBytes(_jwtOptions.Key);



            //3- token descriptor :( Name , role , email ) + expire == session timeout + sign credential == Hmacsha256signtre (method) 
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                //userName, roleName
                Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, firstName),
                        new Claim(ClaimTypes.Role, role),
                        new Claim(ClaimTypes.Email, email)
                    }),

                //expire == session timeout
                Expires = DateTime.UtcNow.AddSeconds(10),

                //sign credential ==(to assign which encoding method to use) "Hmacsha256signutre"(method used to encode data)
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)

            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string GenerateRefreshToken(int userId)
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                var refreshToken = Convert.ToBase64String(randomNumber);
                var model = new RefreshToken
                {
                    UserId = userId,
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

                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtOptions.Key))
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                //throw new SecurityTokenException("Invalid token");
                return null;
            }
                

            return principal;
        }
    }
}
