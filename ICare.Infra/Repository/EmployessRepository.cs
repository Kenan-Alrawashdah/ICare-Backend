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
    public class EmployessRepository : IEmployessRepository
    {
        private readonly IDbContext _dbContext;

        public EmployessRepository(IDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public bool Create(Employee employeeModle)
        {
            var p = new DynamicParameters();
            p.Add("@UserId", employeeModle.UserId, DbType.Int32, ParameterDirection.Input);
            p.Add("@CreatedOn", employeeModle.CreatedOn, DbType.Date, ParameterDirection.Input);
            p.Add("@HourSalary", employeeModle.HourSalary, DbType.Double, ParameterDirection.Input);
            p.Add("@MonthlyWorkingHours", employeeModle.MonthlyWorkingHours, DbType.Double, ParameterDirection.Input);
            p.Add("@PricePerHour", employeeModle.PricePerHour, DbType.Double, ParameterDirection.Input);
            
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
            var p = new DynamicParameters();
            p.Add("@Id", id, dbType: DbType.Int32, ParameterDirection.Input);

            try
            {
                var result = _dbContext.Connection.Execute("EmployeeDelete", p, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Employee> GetAll()
        {
            var result = _dbContext.Connection.Query<Employee>("GetAllEmployees", commandType: CommandType.StoredProcedure);
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
            p.Add("@Id", employeeModle.Id, DbType.Int32, ParameterDirection.Input);
            p.Add("@UserId", employeeModle.UserId, DbType.Int32, ParameterDirection.Input);
            p.Add("@CreatedOn", employeeModle.CreatedOn, DbType.Date, ParameterDirection.Input);
            p.Add("@HourSalary", employeeModle.HourSalary, DbType.Double, ParameterDirection.Input);
            p.Add("@MonthlyWorkingHours", employeeModle.MonthlyWorkingHours, DbType.Double, ParameterDirection.Input);
            p.Add("@PricePerHour", employeeModle.PricePerHour, DbType.Double, ParameterDirection.Input);

            try
            {
                var result = _dbContext.Connection.Execute("EmployeeUpdate", p, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
