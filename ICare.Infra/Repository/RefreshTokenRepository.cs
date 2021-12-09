using Dapper;
using ICare.Core.Data;
using ICare.Core.ICommon;
using ICare.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace ICare.Infra.Repository
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly IDbContext _dbContext;

        public RefreshTokenRepository(IDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        /// <summary>
        /// Delete the refresh token if there is any recored with the same user id 
        /// and add the new recored
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        public bool AddRefreshToken(RefreshToken refreshToken)
        {
            var p = new DynamicParameters();
            p.Add("@UserId",refreshToken.UserId,DbType.Int32,ParameterDirection.Input);
            p.Add("@RefreshToken", refreshToken.RToken,DbType.String,ParameterDirection.Input);
            try
            {
               _dbContext.Connection.ExecuteAsync("RefreshTokenInsert", p, commandType: CommandType.StoredProcedure);
               return true;
            }
            catch (Exception e)
            {
               return false;
            }
        }

        public async Task<RefreshToken> GetRefreshTokenByUserId(int userId)
        {
            var p = new DynamicParameters();
            p.Add("@UserId", userId, DbType.Int32, ParameterDirection.Input);
            try
            {
               var result =await  _dbContext.Connection.QueryFirstOrDefaultAsync<RefreshToken>("GetRefreshTokenByUserId", p, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception e)
            {
                return null;
            }

        }



    }
}
