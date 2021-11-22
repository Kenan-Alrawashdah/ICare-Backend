using Dapper;
using ICare.Core.Data;
using ICare.Core.ICommon;
using ICare.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ICare.Infra.Repository
{
    public class UserLoginsRepository : IUserLoginsRepository
    {
        private readonly IDbContext _dbContext;

        public UserLoginsRepository(IDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public bool Create(UserLogins userTokensModle)
        {
            var p = new DynamicParameters();
            p.Add("@UserId", userTokensModle.UserId, DbType.Int32, ParameterDirection.Input);
            p.Add("@CreatedOn", userTokensModle.CreatedOn, DbType.Date, ParameterDirection.Input);
            p.Add("@LoginProvider", userTokensModle.LoginProvider, DbType.String, ParameterDirection.Input);
            p.Add("@ProviderDisplayName", userTokensModle.ProviderDisplayName, DbType.String, ParameterDirection.Input);
            p.Add("@ProviderKey", userTokensModle.ProviderKey, DbType.String, ParameterDirection.Input);

            try
            {
                var result = _dbContext.Connection.Execute("UserLoginsInsert", p, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception)
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
                var result = _dbContext.Connection.Execute("UserLoginsDelete", p, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<UserLogins> GetAll()
        {
            var result = _dbContext.Connection.Query<UserLogins>("UserLoginsGetAll", commandType: CommandType.StoredProcedure);
            return result;
        }

        public UserLogins GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, DbType.Int32, ParameterDirection.Input);
            var result = _dbContext.Connection.QueryFirstOrDefault<UserLogins>("UserLoginsSelect", p, commandType: CommandType.StoredProcedure);
            return result;
        }

        public bool Update(UserLogins userTokensModle)
        {
            var p = new DynamicParameters();
            p.Add("@Id", userTokensModle.Id, DbType.Int32, ParameterDirection.Input);
            p.Add("@UserId", userTokensModle.UserId, DbType.Int32, ParameterDirection.Input);
            p.Add("@CreatedOn", userTokensModle.CreatedOn, DbType.Date, ParameterDirection.Input);
            p.Add("@LoginProvider", userTokensModle.LoginProvider, DbType.String, ParameterDirection.Input);
            p.Add("@ProviderDisplayName", userTokensModle.ProviderDisplayName, DbType.String, ParameterDirection.Input);
            p.Add("@ProviderKey", userTokensModle.ProviderKey, DbType.String, ParameterDirection.Input);

            try
            {
                var result = _dbContext.Connection.Execute("UserLoginsUpdate", p, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
