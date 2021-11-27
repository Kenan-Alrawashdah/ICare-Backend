using ICare.Core.Data;
using ICare.Core.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICare.API.Controllers
{
    [Authorize(Roles = "Employee")]
    [Route("api/[controller]")]
    [ApiController]
    public class WorkController : ControllerBase
    {
        private readonly IWorkService _workService;
        private readonly IUserServices _userServices;

        public WorkController(IWorkService workService, IUserServices userServices)
        {
            _workService = workService;
            _userServices = userServices;
        }

        [HttpGet]
        public void StartWork()
        {
            var user = _userServices.GetUser(User);
            Work work = new Work { 
              StartDate = DateTime.Now,
              EmployeeId = 1,             
            };
            _workService.StartWork(work);
        }

        [HttpPut]
        public void EndWork()
        {
            _workService.EndWork(1, DateTime.Now);
        }
    }
}
