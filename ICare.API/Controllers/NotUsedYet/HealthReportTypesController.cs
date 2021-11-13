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
//    public class HealthReportTypesController : ControllerBase
//    {
//        private readonly IHealthReportTypesServices _HealthReportTypesServices;

//        public HealthReportTypesController(IHealthReportTypesServices HealthReportTypesServices)
//        {
//            this._HealthReportTypesServices = HealthReportTypesServices;
//        }
//        [HttpPost]
//        [Route("Create")]
//        [ProducesResponseType(type: typeof(bool), StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        public bool Create(HealthReportTypes healthReportTypes)
//        {
//            return _HealthReportTypesServices.Create(healthReportTypes);
//        }

//        [HttpPut]
//        [Route("Update")]
//        [ProducesResponseType(type: typeof(bool), StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        public bool Update(HealthReportTypes healthReportTypes)
//        {
//            return _HealthReportTypesServices.Update(healthReportTypes);
//        }

//        [HttpDelete]
//        [Route("Delete/{id}")]
//        [ProducesResponseType(type: typeof(bool), StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        public bool Delete(int id)
//        {
//            return _HealthReportTypesServices.Delete(id);
//        }

//        [HttpGet]
//        [Route("GetById/{id}")]
//        [ProducesResponseType(type: typeof(HealthReportTypes), StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        public HealthReportTypes GetById(int id)
//        {
//            return _HealthReportTypesServices.GetById(id);
//        }

//        [HttpGet]
//        [Route("GetAll")]
//        [ProducesResponseType(type: typeof(IEnumerable<HealthReportTypes>), StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        public IEnumerable<HealthReportTypes> GetAll()
//        {
//            return _HealthReportTypesServices.GetAll();
//        }
//    }
//}
