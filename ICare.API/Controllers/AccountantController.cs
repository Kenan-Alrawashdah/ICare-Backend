using ICare.Core.ApiDTO;
using ICare.Core.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountantController : ControllerBase
    {
        private readonly IAccountantService _accountantService;

        public AccountantController(IAccountantService accountantService)
        {
            this._accountantService = accountantService;
        }
        [HttpGet]
        [Route("AnnualCareSystemReport")]
        public async Task<ActionResult> AnnualCareSystemReport()
        {

             var theTopContext=await _accountantService.AnnualCareSystemReport();



            var builder = new StringBuilder();
            builder.AppendLine("Name,Order Amount,Profits,OrderDate");
            foreach (var item in theTopContext)
            {

               builder.AppendLine($"{item.Name},{item.OrderAmount + "$"},{item.Profits },{item.OrderDate}");
                         
            }
            return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "AnnualCareSystemReport.csv");
        }
        [HttpGet]
        [Route("MonthlyCareSystemReport")]
        public async Task<ActionResult> MonthlyCareSystemReport()
        {

            var MonthlyCareSystemReport = await _accountantService.MonthlyCareSystemReport();

            var builder = new StringBuilder();
            builder.AppendLine("Name,Order Amount,Profits,Order Date");
            foreach (var item in MonthlyCareSystemReport)
            {

                builder.AppendLine($"{item.Name},{item.OrderAmount + "$"},{item.Profits },{item.OrderDate}");

            }
            return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "MonthlyCareSystemReport.csv");
            
        }
        [HttpGet]
        [Route("DailyCareSystemReport")]
        public async Task<ActionResult> DailyCareSystemReport()
        {

            var DailyCareSystem = await _accountantService.DailyCareSystemReport();



            var builder = new StringBuilder();
            builder.AppendLine("Name,Order Amount,Profits,OrderDate");
            foreach (var item in DailyCareSystem)
            {

                builder.AppendLine($"{item.Name},{item.OrderAmount + "$"},{item.Profits },{item.OrderDate}");

            }
            return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "DailyCareSystemReport.csv");
        }

        [HttpGet]
        [Route("getRegisteredDailyCount")]
        public ActionResult<ApiResponse<getRegisteredDailyCountDTO>> getRegisteredDailyCount()
        {

            var response = new ApiResponse<getRegisteredDailyCountDTO>();
            var RegisteredDailyCount = _accountantService.getRegisteredDailyCount();
            response.Data = new getRegisteredDailyCountDTO();
            response.Data = RegisteredDailyCount;
            return Ok(response);


        }
        [HttpGet]
        [Route("getRegisteredMonthlyCount")]
        public ActionResult<ApiResponse<getRegisteredMonthlyCountDTO>> getRegisteredMonthlyCount()
        {

            var response = new ApiResponse<getRegisteredMonthlyCountDTO>();
            var RegisteredMonthlyCount = _accountantService.getRegisteredMonthlyCount();
            response.Data = new getRegisteredMonthlyCountDTO();
            response.Data = RegisteredMonthlyCount;
            return Ok(response);


        }
        [HttpGet]
        [Route("getRegisteredAnnualCount")]
        public ActionResult<ApiResponse<getRegisteredAnnualCountDTO>> getRegisteredAnnualCount()
        {

            var response = new ApiResponse<getRegisteredAnnualCountDTO>();
            var RegisteredAnnualCount = _accountantService.getRegisteredAnnualCount();
            response.Data = new getRegisteredAnnualCountDTO();

            response.Data = RegisteredAnnualCount;
            return Ok(response);


        }
        [HttpGet]
        [Route("getMonthlyEmployeeSalaries")]
        public ActionResult<ApiResponse<getMonthlyEmployeeSalariesDTO>> getMonthlyEmployeeSalaries()
        {

            var response = new ApiResponse<getMonthlyEmployeeSalariesDTO>();
            var MonthlyEmployeeSalaries = _accountantService.getMonthlyEmployeeSalaries();
            response.Data = new getMonthlyEmployeeSalariesDTO();

            response.Data = MonthlyEmployeeSalaries;
            return Ok(response);


        }
        [HttpGet]
        [Route("getAnnualEmployeeSalaries")]
        public ActionResult<ApiResponse<getAnnualEmployeeSalariesDTO>> getAnnualEmployeeSalaries()
        {

            var response = new ApiResponse<getAnnualEmployeeSalariesDTO>();
            var AnnualEmployeeSalaries = _accountantService.getAnnualEmployeeSalaries();
            response.Data = new getAnnualEmployeeSalariesDTO();

            response.Data = AnnualEmployeeSalaries;
            return Ok(response);


        }
    }
}
