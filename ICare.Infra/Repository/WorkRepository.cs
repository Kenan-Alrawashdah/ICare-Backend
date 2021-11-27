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
  public  class WorkRepository : IWorkRepository
    {
        private readonly IDbContext _dbContext;

        public WorkRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void StartWork(Work work)
        {

            var data = GetStartWork(work.EmployeeId);

             if (data == null)
            {
                try
                {
                    var param = new DynamicParameters();

                    param.Add("@CreatedOn", work.CreatedOn, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    param.Add("@StartDate", work.StartDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    param.Add("@EmployeeId", work.EmployeeId, dbType: DbType.Int32, direction: ParameterDirection.Input);


                    _dbContext.Connection.Execute("StartWork", param, commandType: CommandType.StoredProcedure);
                }
                catch (Exception erorr)
                {
                }
            }

        }
        public void EndWork(int employeeId, DateTime endDate)
        {
            var data = GetStartWork(employeeId);
            if(data.StartDate != null && data.EndDate == null)
            {
                try
                {
                    var param = new DynamicParameters();

                    param.Add("@EndDate", endDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    param.Add("@EmployeeId", employeeId, dbType: DbType.Int32, direction: ParameterDirection.Input);


                    _dbContext.Connection.Execute("EndWork", param, commandType: CommandType.StoredProcedure);
                }
                catch (Exception erorr)
                {
                }
            }
        }

        public Work GetStartWork(int employeeId)
        {
            var p = new DynamicParameters();
            p.Add("@EmployeeId", employeeId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var data = _dbContext.Connection.QueryFirstOrDefault<Work>("GetSartWork", p, commandType: CommandType.StoredProcedure);

            return data;
        }
    }
}
