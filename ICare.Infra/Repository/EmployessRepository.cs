using Dapper;
using ICare.Core.ApiDTO;
using ICare.Core.ApiDTO.Admin.Role;
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
    public class EmployessRepository : IEmployessRepository
    {
        private readonly IDbContext _dbContext;

        public EmployessRepository(IDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<bool> RegistrationEmployee(RegistrationEmployeeApiDTO.Request userModle)
        {
           
            var p = new DynamicParameters();
            p.Add("@Email", userModle.Email, DbType.String, ParameterDirection.Input);
            p.Add("@CreatedOn", DateTime.UtcNow, DbType.DateTime, ParameterDirection.Input);
            p.Add("@PasswordHash", userModle.Password, DbType.String, ParameterDirection.Input);
            p.Add("@PhoneNumber", userModle.PhoneNumber, DbType.String, ParameterDirection.Input);
            p.Add("@FirstName", userModle.FirstName, DbType.String, ParameterDirection.Input);
            p.Add("@LastName", userModle.LastName, DbType.String, ParameterDirection.Input);
            p.Add("@RoleId", userModle.RoleId, DbType.Int32, ParameterDirection.Input);
            //TODO
            //p.Add("@ProfilePicturePath", null, DbType.String, ParameterDirection.Input);



            try
            {
                var userId = await _dbContext.Connection.ExecuteScalarAsync<int>("UserInsert", p, commandType: CommandType.StoredProcedure);

                var employee = new Employee();
                employee.UserId = userId;
                employee.HourSalary = userModle.HourSalary;
                employee.MonthlyWorkingHours = userModle.MonthlyWorkingHours;
                if (!Create(employee))
                {
                    return false;
                }
                return true;
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
                return false;
            }
            return true;
        }
        public async Task<bool> UpdateEmployee(EditEmployeeApiDTO.Request userModle)
        {
           
            var p = new DynamicParameters();
            p.Add("@Id", userModle.Id, DbType.Int32, ParameterDirection.Input);
            p.Add("@PhoneNumber", userModle.PhoneNumber, DbType.String, ParameterDirection.Input);
            p.Add("@FirstName", userModle.FirstName, DbType.String, ParameterDirection.Input);
            p.Add("@LastName", userModle.LastName, DbType.String, ParameterDirection.Input);
            //TODO
            //p.Add("@ProfilePicturePath", null, DbType.String, ParameterDirection.Input);



            try
            {
                var employee = new Employee();
                employee.UserId = userModle.Id;
                employee.HourSalary = userModle.HourSalary;
                employee.MonthlyWorkingHours = userModle.MonthlyWorkingHours;
                if (!Update(employee))
                {
                    return false;
                }
                return true;
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
                return false;
            }
            return true;
        }
        public bool Create(Employee employeeModle)
        {
            var p = new DynamicParameters();
            p.Add("@UserId", employeeModle.UserId, DbType.Int32, ParameterDirection.Input);
            p.Add("@CreatedOn", employeeModle.CreatedOn, DbType.Date, ParameterDirection.Input);
            p.Add("@PricePerHour", employeeModle.HourSalary, DbType.Double, ParameterDirection.Input);
            p.Add("@DailyWorkingHours", employeeModle.MonthlyWorkingHours, DbType.Double, ParameterDirection.Input);
            //p.Add("@PricePerHour", employeeModle.PricePerHour, DbType.Double, ParameterDirection.Input);
            
            try
            {
                var result = _dbContext.Connection.Execute("EmployeeInsert", p, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception )
            { 
                return false;
            }
        }

        public bool Delete(int id)
        {
            //var p = new DynamicParameters();
            //p.Add("@Id", id, dbType: DbType.Int32, ParameterDirection.Input);

            //try
            //{
            //    var result = _dbContext.Connection.Execute("EmployeeDelete", p, commandType: CommandType.StoredProcedure);
            //    return true;
            //}
            //catch (Exception)
            //{
            //    return false;
            //}
            return false;
        }

        public IEnumerable<Employee> GetAll()
        {
            var result = _dbContext.Connection.Query<Employee>("EmployeesGetAll", commandType: CommandType.StoredProcedure);
            return result;
        }
        public Employee GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, DbType.Int32, ParameterDirection.Input);
            var result = _dbContext.Connection.QueryFirstOrDefault<Employee>("EmployeeSelect", p, commandType: CommandType.StoredProcedure);
            return result;
        }
        public bool Update(Employee employeeModle)
        {
            var p = new DynamicParameters();
            p.Add("@UserId", employeeModle.UserId, DbType.Int32, ParameterDirection.Input);
            p.Add("@HourSalary", employeeModle.HourSalary, DbType.Double, ParameterDirection.Input);
            p.Add("@MonthlyWorkingHours", employeeModle.MonthlyWorkingHours, DbType.Double, ParameterDirection.Input);

            try
            {
                var result = _dbContext.Connection.Execute("EmployeeUpdate", p, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
                return false;
            }
        }

        public IEnumerable<GetRolesDTO.Response> GetAllRoles()
        {
            var roles = _dbContext.Connection.Query<GetRolesDTO.Response>
                      ("GetAllRoles", commandType: CommandType.StoredProcedure);

            return roles;
        }
    }
}
