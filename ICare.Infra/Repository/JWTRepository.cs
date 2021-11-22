using Dapper;
using ICare.Core.ApiDTO;
using ICare.Core.DTO;
using ICare.Core.ICommon;
using ICare.Core.IRepository;
using ICare.Core.IServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ICare.Infra.Repository
{
   public class JWTRepository : IJWTRepository
    {
        private readonly IDbContext _dbContext;
        private readonly IPasswordHashingService _passwordHashingService;

        public JWTRepository(IDbContext dbContext, IPasswordHashingService passwordHashingService)
        {
            this._dbContext = dbContext;
            this._passwordHashingService = passwordHashingService;
        }

        public ResponseLoginDTO Authentication(LoginApiDTO.Request loginDTO)
        {
            var z = new DynamicParameters();
            z.Add("@Email", loginDTO.Email, dbType: DbType.String, ParameterDirection.Input);
            var hashedPassword = _dbContext.Connection.QueryFirstOrDefault<string>("GetPasswordByEmail", z, commandType: CommandType.StoredProcedure);
            if(hashedPassword == null)
            {
                return null;
            }
            if(!_passwordHashingService.Authenticate(loginDTO.Password, hashedPassword))
            {
                return null;
            }


            var p = new DynamicParameters();
            p.Add("@Email", loginDTO.Email, dbType: DbType.String, ParameterDirection.Input);
            var result = _dbContext.Connection.QueryFirstOrDefault<ResponseLoginDTO>("AuthLogin", p, commandType: CommandType.StoredProcedure);

            var e = new DynamicParameters();
            e.Add("@Id", result.RoleId, dbType: DbType.Int32, ParameterDirection.Input);
            result.RoleName = _dbContext.Connection.QueryFirstOrDefault<string>("GetRoleyNameById", e, commandType: CommandType.StoredProcedure);

          

            return result;
        }
    }
}
