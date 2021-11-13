//using ICare.Core.Data;
//using ICare.Core.IServices;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace ICare.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ScheduleEnumController : ControllerBase
//    {
//        private readonly IScheduleEnumServices _scheduleEnumServices;
//        public ScheduleEnumController(IScheduleEnumServices ICRUDServices)
//        {
//            this._scheduleEnumServices = ICRUDServices;
//        }
//        [HttpPost]
//        [Route("Create")]
//        [ProducesResponseType(typeof(ScheduleEnum), StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        public bool Create(ScheduleEnum t)
//        {
//            return _scheduleEnumServices.Create(t);
//        }
//        [HttpDelete, Route("delete/{id}")]
//        public bool Delete(int id)
//        {
//            return _scheduleEnumServices.Delete(id);
//        }
//        [HttpGet]
//        [Route("GetAll")]
//        public IEnumerable<ScheduleEnum> GetAll()
//        {
//            return _scheduleEnumServices.GetAll();
//        }
//        [HttpGet]
//        [Route("GetById/{id}")]
//        public ScheduleEnum GetById(int id)
//        {
//            return _scheduleEnumServices.GetById(id);

//        }
//        [HttpPut]
//        [Route("Update")]
//        public bool Update(ScheduleEnum t)
//        {
//            return _scheduleEnumServices.Update(t);

//        }
//    }
//}
