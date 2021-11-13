using ICare.Core.ApiDTO;
using ICare.Core.DTO;
using ICare.Core.IRepository;
using ICare.Core.IServices;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ICare.Infra.Services
{

    public class JWTService : IJWTService
    {
        private readonly IJWTRepository _jWTRepository;

        public JWTService(IJWTRepository jWTRepository)
        {
            this._jWTRepository = jWTRepository;
        }

        public string Auth(LoginApiDTO.Request loginDTO)
        {
            var result = _jWTRepository.Authentication(loginDTO);

            if (result == null)
            {
                return null;
            }
            else
            {
                //1- token handler : generate token
                var tokenHandler = new JwtSecurityTokenHandler();


                //2- token key : to encode data to token (secure value)
                var tokenKey = Encoding.ASCII.GetBytes("[Hello my Name is Anas Ahmad Alfasatleh]");


                //3- token descriptor :( userName , roleNoleName) + expire == session timeout + sign credential == Hmacsha256signtre (method) 
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    //userName, roleName
                    Subject = new ClaimsIdentity(new Claim[]
                        {
                    new Claim(ClaimTypes.Name, result.FirstName),
                    new Claim(ClaimTypes.Role, result.RoleName[0]),
                    new Claim(ClaimTypes.Email , result.Email)
                         }),

                    //expire == session timeout
                    Expires = DateTime.UtcNow.AddHours(1),

                    //signcredintial ==(to assgin which encoding method to use) "Hmacsha256signutre"(method used to encode data)
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256)

                };


                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);



            }
        }

        public string Auth(string email, string password)
        {
            var loginDTO = new LoginApiDTO.Request();
            loginDTO.Email = email;
            loginDTO.Password = password;
            return Auth(loginDTO);
        }
    }
}

