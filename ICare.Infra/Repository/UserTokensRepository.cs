using Dapper;
using ICare.Core.Data;
using ICare.Core.ICommon;
using ICare.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Data;

namespace ICare.Infra.Repository
{
    public class UserTokensRepository : IUserTokensRepository
    {
        private readonly IDbContext _dbContext;

        public UserTokensRepository(IDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public bool Create(UserTokens userTokensModle)
        {
            var p = new DynamicParameters();
            p.Add("@UserId", userTokensModle.UserId, DbType.Int32, ParameterDirection.Input);
            p.Add("@CreatedOn", userTokensModle.CreatedOn, DbType.Date, ParameterDirection.Input);
            p.Add("@LoginProvider", userTokensModle.LoginProvider, DbType.String, ParameterDirection.Input);
            p.Add("@Name", userTokensModle.Name, DbType.String, ParameterDirection.Input);
            p.Add("@Value", userTokensModle.Value, DbType.String, ParameterDirection.Input);

            try
            {
                var result = _dbContext.Connection.Execute("UserTokensInsert", p, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, dbType: DbType.Int32, ParameterDirection.Input);

            try
            {
                var result = _dbContext.Connection.Execute("UserTokensDelete", p, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<UserTokens> GetAll()
        {
            var result = _dbContext.Connection.Query<UserTokens>("GetAllUserTokens", commandType: CommandType.StoredProcedure);
            return result;
        }

        public UserTokens GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, DbType.Int32, ParameterDirection.Input);
            var result = _dbContext.Connection.QueryFirstOrDefault<UserTokens>("UserTokensSelect", p, commandType: CommandType.StoredProcedure);
            return result;
        }

        public bool Update(UserTokens userTokensModle)
        {
            var p = new DynamicParameters();
            p.Add("@Id", userTokensModle.Id, DbType.Int32, ParameterDirection.Input);
            p.Add("@UserId", userTokensModle.UserId, DbType.Int32, ParameterDirection.Input);
            p.Add("@CreatedOn", userTokensModle.CreatedOn, DbType.Date, ParameterDirection.Input);
            p.Add("@LoginProvider", userTokensModle.LoginProvider, DbType.String, ParameterDirection.Input);
            p.Add("@Name", userTokensModle.Name, DbType.String, ParameterDirection.Input);
            p.Add("@Value", userTokensModle.Value, DbType.String, ParameterDirection.Input);

            try
            {
                var result = _dbContext.Connection.Execute("UserTokensUpdate", p, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
