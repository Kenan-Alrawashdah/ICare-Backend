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
    public class UserRepository : IUserRepository
    {
        private readonly IDbContext _dbContext;

        public UserRepository(IDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public bool Create(ApplicationUser userModle)
        {
            var p = new DynamicParameters();
            p.Add("@Email", userModle.Email, DbType.String, ParameterDirection.Input);
            p.Add("@CreatedOn", userModle.CreatedOn, DbType.Date, ParameterDirection.Input);
            p.Add("@PasswordHash", userModle.PasswordHash, DbType.String, ParameterDirection.Input);
            p.Add("@PhoneNumber", userModle.PhoneNumber, DbType.String, ParameterDirection.Input);
            p.Add("@FirstName", userModle.FirstName, DbType.String, ParameterDirection.Input);
            p.Add("@LastName", userModle.LastName, DbType.String, ParameterDirection.Input);
            p.Add("@ProfilePicturePath", userModle.ProfilePicturePath, DbType.String, ParameterDirection.Input);
            p.Add("@LocationId", userModle.LocationId, DbType.Int32, ParameterDirection.Input);
            p.Add("@EmployeeId", userModle.EmployeeId, DbType.Int32, ParameterDirection.Input);
            p.Add("@PatientId", userModle.PatientId, DbType.Int32, ParameterDirection.Input);

            try
            {
                var result = _dbContext.Connection.Execute("UserInsert", p, commandType: CommandType.StoredProcedure);
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
                var result = _dbContext.Connection.Execute("UserDelete", p, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            var result = _dbContext.Connection.Query<ApplicationUser>("GetAllUsers", commandType: CommandType.StoredProcedure);
            return result;
        }

        public ApplicationUser GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, DbType.Int32, ParameterDirection.Input);
            var result = _dbContext.Connection.QueryFirstOrDefault<ApplicationUser>("UserSelect", p, commandType: CommandType.StoredProcedure);
            return result;
        }

        public bool Update(ApplicationUser userModle)
        {
            var p = new DynamicParameters();
            p.Add("@Id", userModle.Id, DbType.Int32, ParameterDirection.Input);
            p.Add("@Email", userModle.Email, DbType.String, ParameterDirection.Input);
            p.Add("@CreatedOn", userModle.CreatedOn, DbType.Date, ParameterDirection.Input);
            p.Add("@PasswordHash", userModle.PasswordHash, DbType.String, ParameterDirection.Input);
            p.Add("@PhoneNumber", userModle.PhoneNumber, DbType.String, ParameterDirection.Input);
            p.Add("@FirstName", userModle.FirstName, DbType.String, ParameterDirection.Input);
            p.Add("@LastName", userModle.LastName, DbType.String, ParameterDirection.Input);
            p.Add("@ProfilePicturePath", userModle.ProfilePicturePath, DbType.String, ParameterDirection.Input);
            p.Add("@LocationId", userModle.LocationId, DbType.Int32, ParameterDirection.Input);
            p.Add("@EmployeeId", userModle.EmployeeId, DbType.Int32, ParameterDirection.Input);
            p.Add("@PatientId", userModle.PatientId, DbType.Int32, ParameterDirection.Input);

            try
            {
                var result = _dbContext.Connection.Execute("UserUpdate", p, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
