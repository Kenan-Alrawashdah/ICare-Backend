using ICare.Core.ApiDTO;
using ICare.Core.IRepository;
using ICare.Core.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ICare.Infra.Services
{
    public class AccountantService : IAccountantService
    {
        private readonly IAccountantRepository _accountantRepository;

        public AccountantService(IAccountantRepository accountantRepository)
        {
            this._accountantRepository = accountantRepository;
        }
        public async Task<IEnumerable<CareSystemReportDTO>> AnnualCareSystemReport()
        {
            return await _accountantRepository.AnnualCareSystemReport();
        }

        public async Task<IEnumerable<CareSystemReportDTO>> DailyCareSystemReport()
        {
            return await _accountantRepository.DailyCareSystemReport();
        }

        public getAnnualEmployeeSalariesDTO getAnnualEmployeeSalaries()
        {
            return _accountantRepository.getAnnualEmployeeSalaries();
        }

        public getMonthlyEmployeeSalariesDTO getMonthlyEmployeeSalaries()
        {
            return _accountantRepository.getMonthlyEmployeeSalaries();
        }

        public getRegisteredAnnualCountDTO getRegisteredAnnualCount()
        {
            return  _accountantRepository.getRegisteredAnnualCount();
        }

        public getRegisteredDailyCountDTO getRegisteredDailyCount()
        {
            return _accountantRepository.getRegisteredDailyCount();
        }

        public getRegisteredMonthlyCountDTO getRegisteredMonthlyCount()
        {
            return _accountantRepository.getRegisteredMonthlyCount();
        }

        public async Task<IEnumerable<CareSystemReportDTO>> MonthlyCareSystemReport()
        {
            return await _accountantRepository.MonthlyCareSystemReport();
        }
    }
}
