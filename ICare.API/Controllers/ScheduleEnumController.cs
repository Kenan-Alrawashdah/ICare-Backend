using ICare.Core.Data;
using ICare.Core.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleEnumController : ControllerBase
    {
        private readonly ICRUDServices<ScheduleEnum> ICRUDServices;
        public ScheduleEnumController(ICRUDServices<ScheduleEnum> ICRUDServices)
        {
            this.ICRUDServices = ICRUDServices;
        }
        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(typeof(ScheduleEnum), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool Create(ScheduleEnum t)
        {
            return ICRUDServices.Create(t);
        }
        [HttpDelete, Route("delete/{id}")]
        public bool Delete(int id)
        {
            return ICRUDServices.Delete(id);
        }
        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<ScheduleEnum> GetAll()
        {
            return ICRUDServices.GetAll();
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public ScheduleEnum GetById(int id)
        {
            return ICRUDServices.GetById(id);

        }
        [HttpPut]
        [Route("Update")]
        public bool Update(ScheduleEnum t)
        {
            return ICRUDServices.Update(t);

        }
    }
}
