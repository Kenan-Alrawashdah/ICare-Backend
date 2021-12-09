using Dapper;
using ICare.Core.ApiDTO;
using ICare.Core.ICommon;
using ICare.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace ICare.Infra.Repository
{
    public class AccountantRepository : IAccountantRepository
    {
        private readonly IDbContext _dbContext;

        public AccountantRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<CareSystemReportDTO>> AnnualCareSystemReport()
        {
            var Annual = await _dbContext.Connection.QueryAsync<CareSystemReportDTO>("AnnualCareSystemReport", commandType: CommandType.StoredProcedure);

            return Annual;
        }

        public async Task<IEnumerable<CareSystemReportDTO>> DailyCareSystemReport()
        {
            var Daily = await _dbContext.Connection.QueryAsync<CareSystemReportDTO>("DailyCareSystemReport", commandType: CommandType.StoredProcedure);

            return Daily;
        }

        public getAnnualEmployeeSalariesDTO getAnnualEmployeeSalaries()
        {
                var Daily = _dbContext.Connection.QueryFirstOrDefault<getAnnualEmployeeSalariesDTO>("getAnnualEmployeeSalaries", commandType: CommandType.StoredProcedure);

                return Daily;
        }

        public getMonthlyEmployeeSalariesDTO getMonthlyEmployeeSalaries()
        {

                var Daily = _dbContext.Connection.QueryFirstOrDefault<getMonthlyEmployeeSalariesDTO>("getMonthlyEmployeeSalaries", commandType: CommandType.StoredProcedure);
                return Daily;

            

        }

        public getRegisteredAnnualCountDTO getRegisteredAnnualCount()
        {
            var Daily =  _dbContext.Connection.QueryFirstOrDefault<getRegisteredAnnualCountDTO>("getRegisteredAnnual", commandType: CommandType.StoredProcedure);

            return Daily;
        }

        public getRegisteredDailyCountDTO getRegisteredDailyCount()
        {
            var Daily =  _dbContext.Connection.QueryFirstOrDefault<getRegisteredDailyCountDTO>("getRegisteredDaily", commandType: CommandType.StoredProcedure);

            return Daily;
        }

        public getRegisteredMonthlyCountDTO getRegisteredMonthlyCount()
        {
            var Daily =  _dbContext.Connection.QueryFirstOrDefault<getRegisteredMonthlyCountDTO>("getRegisteredMonthly", commandType: CommandType.StoredProcedure);

            return Daily;
        }

        public async Task<IEnumerable<CareSystemReportDTO>> MonthlyCareSystemReport()
        {
            var Monthly = _dbContext.Connection.Query<CareSystemReportDTO>("MonthlyCareSystemReport", commandType: CommandType.StoredProcedure);

            return Monthly;
        }
    }
}
