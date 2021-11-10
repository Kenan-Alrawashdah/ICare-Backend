using Dapper;
using ICare.Core.DTO;
using ICare.Core.ICommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ICare.Infra.Repository
{
   public class JWTRepository
    {
        private readonly IDbContext _dbContext;

        public JWTRepository(IDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public ResponseLoginDTO Authentication(RequestLoginDTO login)
        {
            var p = new DynamicParameters();
            p.Add("@UserName", login.UserName, dbType: DbType.String, ParameterDirection.Input);
            p.Add("@Password", login.Password, dbType: DbType.String, ParameterDirection.Input);

            var result = _dbContext.Connection.QueryFirstOrDefault<ResponseLoginDTO>("AuthLogin", p, commandType: CommandType.StoredProcedure);
            if(result != null)
            { 
            var e = new DynamicParameters();
            p.Add("@Id", result.Id, dbType: DbType.String, ParameterDirection.Input);
            result.RoleName = _dbContext.Connection.QuerySingle<List<string>>("GetUserRoles", e, commandType: CommandType.StoredProcedure);
            }

            return result;
        }
    }
}
