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

    public class AuthService : IAuthService
    {
        private readonly IAuthRespository _authRespository;

        public AuthService(IAuthRespository authRespository)
        {
            this._authRespository = authRespository;
        }

        public ResponseLoginDTO Authentication(LoginApiDTO.Request loginDTO)
        {
            return _authRespository.Authentication(loginDTO); 
        }
        public ResponseLoginDTO Authentication(string email)
        {
            return _authRespository.Authentication(email);
        }
    }
}

