using ICare.Core.ICommon;
using ICare.Infra.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Dapper;
using System.Data;
using ICare.Core.IServices;
using ICare.Core.ApiDTO;
using ICare.Core.Data;

namespace ICare.API.Factories
{
    public static class RoleFactory
    {
        public static async Task ConfigureRoles(this IServiceProvider provider)
        {
            var _dbContext = provider.GetService<IDbContext>();
            var _userServices = provider.GetService<IUserServices>();
            var _passwordSevices = provider.GetService<IPasswordHashingService>();
            var _subscriptionTypeServices = provider.GetService<ISubscriptionTypeServices>();
            // Ensure database exist
            if (_dbContext.Connection.State != ConnectionState.Open)
            {
            await _dbContext.Connection.OpenAsync();
            }

            //Ensure "Admin" Role Exist 
            var a = new DynamicParameters();
            a.Add("@Name", "Admin", DbType.String, ParameterDirection.Input);
            var adminRoleExists = _dbContext.Connection.ExecuteScalar<int?>("GetRoleIdByName", a, commandType: CommandType.StoredProcedure);
            if(adminRoleExists == null)
            {
                var aa = new DynamicParameters();
                aa.Add("@Name", "Admin", DbType.String, ParameterDirection.Input);
                await _dbContext.Connection.ExecuteAsync("RolesInsert", aa, commandType: CommandType.StoredProcedure);
            }

            //Ensure "Patient" Role Exist 
            var p = new DynamicParameters();
            p.Add("@Name", "Patient", DbType.String, ParameterDirection.Input);
            var patientRoleExists = _dbContext.Connection.ExecuteScalar<int?>("GetRoleIdByName", p, commandType: CommandType.StoredProcedure);
            if (patientRoleExists == null)
            {
                var pp = new DynamicParameters();
                pp.Add("@Name", "Patient", DbType.String, ParameterDirection.Input);
                await _dbContext.Connection.ExecuteAsync("RolesInsert", pp, commandType: CommandType.StoredProcedure);
            }

            //Ensure "Subscriber" Role Exist 
            var s = new DynamicParameters();
            s.Add("@Name", "Subscriber", DbType.String, ParameterDirection.Input);
            var subscriberRoleExists = _dbContext.Connection.ExecuteScalar<int?>("GetRoleIdByName", s, commandType: CommandType.StoredProcedure);
            if (subscriberRoleExists == null)
            {
                var ss = new DynamicParameters();
                ss.Add("@Name", "Subscriber", DbType.String, ParameterDirection.Input);
                await _dbContext.Connection.ExecuteAsync("RolesInsert", ss, commandType: CommandType.StoredProcedure);
            }

            //Ensure "Employee" Role Exist 
            var e = new DynamicParameters();
            e.Add("@Name", "Employee", DbType.String, ParameterDirection.Input);
            var employeeRoleExists = _dbContext.Connection.ExecuteScalar<int?>("GetRoleIdByName", e, commandType: CommandType.StoredProcedure);
            if (employeeRoleExists == null)
            {
                var ee = new DynamicParameters();
                ee.Add("@Name", "Employee", DbType.String, ParameterDirection.Input);
                await _dbContext.Connection.ExecuteAsync("RolesInsert", ee, commandType: CommandType.StoredProcedure);
            }



            // Ensure admin user exist
            var d = new DynamicParameters();
            d.Add("@Email", "appAdmin@ICare.net", DbType.String, ParameterDirection.Input);
            var admin = await _dbContext.Connection.ExecuteScalarAsync<int?>("GetUserIdByEmial", d, commandType: CommandType.StoredProcedure);
            if(admin == null)
            {
                var adminUser = new ApplicationUser
                {
                    Email = "appAdmin@ICare.net",
                    FirstName = "Admin",
                    LastName = "ICare",
                    PhoneNumber = "077777777",
                    PasswordHash = _passwordSevices.GetHash("Q!qwe123"),
                    
                };
                await _userServices.AddAdmin(adminUser);
            }


            //Ensure status order is exist
            var statusExists = _dbContext.Connection.ExecuteScalar<int?>("CheckOrderStatus",  commandType: CommandType.StoredProcedure);
            if (statusExists == null)
            {
                await _dbContext.Connection.ExecuteAsync("CreateStatusOrder",  commandType: CommandType.StoredProcedure);
            }

            //Ensure status order is exist
            var subscriptionExists = _dbContext.Connection.ExecuteScalar<int>("CheckSubscribeType", commandType: CommandType.StoredProcedure);
            if (subscriptionExists != 3)
            {
                await _dbContext.Connection.ExecuteAsync("AddSubscribeTypes", commandType: CommandType.StoredProcedure);
            }

        }
    }
}
