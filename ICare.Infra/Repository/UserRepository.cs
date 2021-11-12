﻿using Dapper;
using ICare.Core.ApiDTO;
using ICare.Core.Data;
using ICare.Core.ICommon;
using ICare.Core.IRepository;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;

namespace ICare.Infra.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbContext _dbContext;

        public UserRepository(IDbContext dbContext)
        {
            this._dbContext = dbContext;
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

        [Authorize]
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


        public bool Registration(RegistrationApiDTO.Request userModle)
        {
            var p = new DynamicParameters();
            p.Add("@Email", userModle.Email, DbType.String, ParameterDirection.Input);
            p.Add("@CreatedOn", DateTime.UtcNow, DbType.Date, ParameterDirection.Input);
            p.Add("@PasswordHash", userModle.Password, DbType.String, ParameterDirection.Input);
            p.Add("@PhoneNumber", userModle.PhoneNumber, DbType.String, ParameterDirection.Input);
            p.Add("@FirstName", userModle.FirstName, DbType.String, ParameterDirection.Input);
            p.Add("@LastName", userModle.LastName, DbType.String, ParameterDirection.Input);
            p.Add("@ProfilePicturePath", null, DbType.String, ParameterDirection.Input);
            p.Add("@LocationId", null, DbType.Int32, ParameterDirection.Input);
            p.Add("@EmployeeId", null, DbType.Int32, ParameterDirection.Input);
            p.Add("@PatientId", null, DbType.Int32, ParameterDirection.Input);

            try
            {
                var userId = _dbContext.Connection.ExecuteScalar<int>("UserInsert", p, commandType: CommandType.StoredProcedure);
                var userRoleModle = new UserRoles
                {
                    UserId = userId
                };
                var e = new DynamicParameters();
                e.Add("@Name", "Patient", DbType.String, ParameterDirection.Input);
                userRoleModle.RoleId = _dbContext.Connection.ExecuteScalar<int>("GetRoleIdByName", e, commandType: CommandType.StoredProcedure);
                if(!AddPatientRole(userRoleModle))
                {
                    return false;
                }
                var patient = new Patient();
                patient.UserId = userId;
                if (!CreatePatient(patient))
                {
                    return false;
                }
                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }

        private bool AddPatientRole(UserRoles userRolesModle)
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
            catch (Exception)
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
            catch (Exception)
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