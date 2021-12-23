using Dapper;
using ICare.Core.ApiDTO;
using ICare.Core.Data;
using ICare.Core.ICommon;
using ICare.Core.IRepository;
using ICare.Core.IServices;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;


namespace ICare.Infra.Repository
{
    public class UserRepository : IUserRepository
    {
        
        private readonly IDbContext _dbContext;
        private  IPasswordHashingService _passwordHashingService;
        public UserRepository(IDbContext dbContext, IPasswordHashingService passwordHashingService)
        {
            this._dbContext = dbContext;
            this._passwordHashingService = passwordHashingService;
        }
        public bool CheckEmailExist(string Email)
        {
            var p = new DynamicParameters();
            p.Add("@Email", Email, dbType: DbType.String, ParameterDirection.Input);


            var user = _dbContext.Connection.QueryFirstOrDefault<int?>("GetUserByEmail", p, commandType: CommandType.StoredProcedure);
            if (user == null)
            {
                return false;
            }
            else
            {
                return true;

            }
        }
  

        public ApplicationUser GetUser(ClaimsPrincipal userClaims)
        {
            try
            {
                var email = userClaims.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;
                var p = new DynamicParameters();
                p.Add("@Email", email, dbType: DbType.String, ParameterDirection.Input);
                var user = _dbContext.Connection.QueryFirstOrDefault<ApplicationUser>("GetUserByEmail", p, commandType: CommandType.StoredProcedure);
                return user;
            }
            catch (Exception)
            {
                return null;
            }
        } 
        public ApplicationUser GetUserByEmail(string email)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@Email", email, dbType: DbType.String, ParameterDirection.Input);
                var user = _dbContext.Connection.QueryFirstOrDefault<ApplicationUser>("GetUserByEmail", p, commandType: CommandType.StoredProcedure);
                return user;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<bool> AddAdmin(ApplicationUser userModle)
        {
            var e = new DynamicParameters();
            e.Add("@Name", "Admin", DbType.String, ParameterDirection.Input);
            var roleId = _dbContext.Connection.ExecuteScalar<int>("GetRoleIdByName", e, commandType: CommandType.StoredProcedure);
            var p = new DynamicParameters();
            p.Add("@Email", userModle.Email, DbType.String, ParameterDirection.Input);
            p.Add("@CreatedOn", DateTime.UtcNow, DbType.DateTime, ParameterDirection.Input);
            p.Add("@PasswordHash", userModle.PasswordHash, DbType.String, ParameterDirection.Input);
            p.Add("@PhoneNumber", userModle.PhoneNumber, DbType.String, ParameterDirection.Input);
            p.Add("@FirstName", userModle.FirstName, DbType.String, ParameterDirection.Input);
            p.Add("@LastName", userModle.LastName, DbType.String, ParameterDirection.Input);
            p.Add("@ProfilePicturePath", null, DbType.String, ParameterDirection.Input);
            p.Add("@EmployeeId", null, DbType.Int32, ParameterDirection.Input);
            p.Add("@PatientId", null, DbType.Int32, ParameterDirection.Input);
            p.Add("@RoleId", roleId, DbType.Int32, ParameterDirection.Input);


            await _dbContext.Connection.ExecuteScalarAsync<int>("UserInsert", p, commandType: CommandType.StoredProcedure);
            return true; 
        }


        public async Task<bool> Registration(RegistrationApiDTO.Request userModle)
        {
            var e = new DynamicParameters();
            e.Add("@Name", "Patient", DbType.String, ParameterDirection.Input);
            var roleId = _dbContext.Connection.ExecuteScalar<int>("GetRoleIdByName", e, commandType: CommandType.StoredProcedure);
            var p = new DynamicParameters();
            p.Add("@Email", userModle.Email, DbType.String, ParameterDirection.Input);
            p.Add("@CreatedOn", DateTime.UtcNow, DbType.DateTime, ParameterDirection.Input);
            p.Add("@PasswordHash", userModle.Password, DbType.String, ParameterDirection.Input);
            p.Add("@PhoneNumber", userModle.PhoneNumber, DbType.String, ParameterDirection.Input);
            p.Add("@FirstName", userModle.FirstName, DbType.String, ParameterDirection.Input);
            p.Add("@LastName", userModle.LastName, DbType.String, ParameterDirection.Input);
            p.Add("@RoleId", roleId, DbType.Int32, ParameterDirection.Input);
            //TODO
            p.Add("@ProfilePicturePath", null, DbType.String, ParameterDirection.Input);
            p.Add("@EmployeeId", null, DbType.Int32, ParameterDirection.Input);
            p.Add("@PatientId", null, DbType.Int32, ParameterDirection.Input);
           

            try
            {
                var userId = await _dbContext.Connection.ExecuteScalarAsync<int>("UserInsert", p, commandType: CommandType.StoredProcedure);               

                var patient = new Patient();
                patient.UserId = userId;
                if (!CreatePatient(patient))
                {
                    return false;
                }
                return true;
            }
            catch (Exception ee)
            {
                return false;
            }
        }


        private bool CreatePatient(Patient patient)
        {
            var p = new DynamicParameters();
            p.Add("@CreatedOn", patient.CreatedOn, DbType.DateTime, ParameterDirection.Input);
            p.Add("@UserId", patient.UserId, DbType.Int32, ParameterDirection.Input);
            p.Add("@Liters", patient.Liters, DbType.Double, ParameterDirection.Input);
            p.Add("@SubscriptionValidation", patient.SubscriptionValidation, DbType.DateTime, ParameterDirection.Input);


            try
            {
                var result = _dbContext.Connection.Execute("PatientInsert", p, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool AddOrUpdateProfilePicture(string imagePath, int userId)
        {

            var p = new DynamicParameters();
            p.Add("@imagePath", imagePath, DbType.String, ParameterDirection.Input);
            p.Add("@userId", userId, DbType.Int32, ParameterDirection.Input);
           
            try
            {
                var result = _dbContext.Connection.Execute("AddOrUpdateProfilePicture", p, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception e)
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
            catch (Exception e)
            {
                return false;
            }
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            var result = _dbContext.Connection.Query<ApplicationUser>("UsersGetAll", commandType: CommandType.StoredProcedure);
            return result;
        }

        public ApplicationUser GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, DbType.Int32, ParameterDirection.Input);
            var result = _dbContext.Connection.QueryFirstOrDefault<ApplicationUser>("UserSelect", p, commandType: CommandType.StoredProcedure);
            return result;
        }

        public bool Update(int userId,MyAccountApiDTO.Request Modle)
        {
            var p = new DynamicParameters();
            p.Add("@Id", userId, DbType.Int32, ParameterDirection.Input);
            p.Add("@PhoneNumber", Modle.PhoneNumber, DbType.String, ParameterDirection.Input);
            p.Add("@FirstName", Modle.FirstName, DbType.String, ParameterDirection.Input);
            p.Add("@LastName", Modle.LastName, DbType.String, ParameterDirection.Input);

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

        public IEnumerable<GetBySearchDTO.Response> GetDrugByNameSearch(GetBySearchDTO.Request request)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@Search", request.Search, dbType: DbType.String, ParameterDirection.Input);
                var DrugList = _dbContext.Connection.Query<GetBySearchDTO.Response>("GetBySearch", p, commandType: CommandType.StoredProcedure);
                return DrugList;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> SetNewPassword(string email , string password)
        {
            
                var p = new DynamicParameters();
                p.Add("@Email", email, DbType.String, ParameterDirection.Input);
                p.Add("@NewPasswordHash", password, DbType.String, ParameterDirection.Input);
                try
                {
                    var PasswordChanged = await _dbContext.Connection.ExecuteScalarAsync<string>("ChangeUserPassword", p, commandType: CommandType.StoredProcedure);

                    return true;
                }
                catch (Exception ee)
                {
                    return false;
                }
           
           
        }

        public IEnumerable<getAllEmployeeDTO> getAllEmployee()
        {
            var result = _dbContext.Connection.Query<getAllEmployeeDTO>("getAllEmployee", commandType: CommandType.StoredProcedure);
            return result;
        }

        public async Task<bool> Registration(RegistrationEmployeeApiDTO.Request userModle)
        {
            var e = new DynamicParameters();
            e.Add("@Name", "Patient", DbType.String, ParameterDirection.Input);
            var roleId = _dbContext.Connection.ExecuteScalar<int>("GetRoleIdByName", e, commandType: CommandType.StoredProcedure);
            var p = new DynamicParameters();
            p.Add("@Email", userModle.Email, DbType.String, ParameterDirection.Input);
            p.Add("@CreatedOn", DateTime.UtcNow, DbType.DateTime, ParameterDirection.Input);
            p.Add("@PasswordHash", userModle.Password, DbType.String, ParameterDirection.Input);
            p.Add("@PhoneNumber", userModle.PhoneNumber, DbType.String, ParameterDirection.Input);
            p.Add("@FirstName", userModle.FirstName, DbType.String, ParameterDirection.Input);
            p.Add("@LastName", userModle.LastName, DbType.String, ParameterDirection.Input);
            p.Add("@RoleId", roleId, DbType.Int32, ParameterDirection.Input);
            //TODO
            p.Add("@ProfilePicturePath", null, DbType.String, ParameterDirection.Input);
            p.Add("@EmployeeId", null, DbType.Int32, ParameterDirection.Input);
            p.Add("@PatientId", null, DbType.Int32, ParameterDirection.Input);


            try
            {
                var userId = await _dbContext.Connection.ExecuteScalarAsync<int>("UserInsert", p, commandType: CommandType.StoredProcedure);

                var patient = new Patient();
                patient.UserId = userId;
                if (!CreatePatient(patient))
                {
                    return false;
                }
                return true;
            }
            catch (Exception ee)
            {
                return false;
            }
        }


        public IEnumerable<GetPatientStatsLast5YearDTO> GetPatientStatsLast5Year()
        {
            var result = _dbContext.Connection.Query<GetPatientStatsLast5YearDTO>("GetPatientStatsLast5Year", commandType: CommandType.StoredProcedure);
            return result;
            }

        public bool ChangPassword(int userId,string newPassword)
        {
            var newPass = _passwordHashingService.GetHash(newPassword);
            var p = new DynamicParameters();
            p.Add("@Id", userId, DbType.Int32, ParameterDirection.Input);
            p.Add("@PasswordHash",newPass, DbType.String, ParameterDirection.Input);
            _dbContext.Connection.ExecuteAsync("UpdateUserPassword", p, commandType: CommandType.StoredProcedure);
            return true; 
            }

    }
}
