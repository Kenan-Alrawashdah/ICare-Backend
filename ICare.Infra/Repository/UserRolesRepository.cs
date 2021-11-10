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
    public class UserRolesRepository : IUserRolesRepository
    {
        private readonly IDbContext _dbContext;

        public UserRolesRepository(IDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public bool Create(UserRoles userRolesModle)
        {
            var p = new DynamicParameters();
            p.Add("@RoleId", userRolesModle.RoleId, DbType.Int32, ParameterDirection.Input);
            p.Add("@UserId", userRolesModle.UserId, DbType.Int32, ParameterDirection.Input);
            p.Add("@CreatedOn", userRolesModle.CreatedOn, DbType.Date, ParameterDirection.Input);

            try
            {
                var result = _dbContext.Connection.Execute("UserRolesInsert", p, commandType: CommandType.StoredProcedure);
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
                var result = _dbContext.Connection.Execute("UserRolesDelete", p, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<UserRoles> GetAll()
        {
            var result = _dbContext.Connection.Query<UserRoles>("GetAllUserRole", commandType: CommandType.StoredProcedure);
            return result;
        }

        public UserRoles GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, DbType.Int32, ParameterDirection.Input);
            var result = _dbContext.Connection.QueryFirstOrDefault<UserRoles>("UserRolesSelect", p, commandType: CommandType.StoredProcedure);
            return result;
        }

        public bool Update(UserRoles userRolesModle)
        {
            var p = new DynamicParameters();
            p.Add("@Id", userRolesModle.Id, DbType.Int32, ParameterDirection.Input);
            p.Add("@UserId", userRolesModle.UserId, DbType.Int32, ParameterDirection.Input);
            p.Add("@RoleId", userRolesModle.RoleId, DbType.Int32, ParameterDirection.Input);
            p.Add("@CreatedOn", userRolesModle.CreatedOn, DbType.Date, ParameterDirection.Input);

            try
            {
                var result = _dbContext.Connection.Execute("UserRolesUpdate", p, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

   
    }
}
