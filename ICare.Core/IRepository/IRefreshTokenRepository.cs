using ICare.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ICare.Core.IRepository
{
    public interface IRefreshTokenRepository
    {
        bool AddRefreshToken(RefreshToken refreshToken);
        Task<RefreshToken> GetRefreshTokenByUserId(int userId);
    }
}
