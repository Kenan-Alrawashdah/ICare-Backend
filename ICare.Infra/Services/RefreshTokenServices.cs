using ICare.Core.Data;
using ICare.Core.IRepository;
using ICare.Core.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ICare.Infra.Services
{
    public class RefreshTokenServices : IRefreshTokenServices
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public RefreshTokenServices(IRefreshTokenRepository refreshTokenRepository)
        {
            this._refreshTokenRepository = refreshTokenRepository;
        }

        public bool AddRefreshToken(RefreshToken refreshToken)
        {
            return _refreshTokenRepository.AddRefreshToken(refreshToken);
        }
        public Task<RefreshToken> GetRefreshTokenByUserId(int userId)
        {
            return _refreshTokenRepository.GetRefreshTokenByUserId(userId);
        }
    }
}
