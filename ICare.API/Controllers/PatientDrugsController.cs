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
    public class PatientDrugsController : ControllerBase
    {
        private readonly ICRUDServices<PatientDrugs> ICRUDServices;
        public PatientDrugsController(ICRUDServices<PatientDrugs> ICRUDServices)
        {
            this.ICRUDServices = ICRUDServices;
        }
        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(typeof(PatientDrugs), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool Create(PatientDrugs t)
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
        public IEnumerable<PatientDrugs> GetAll()
        {
            return ICRUDServices.GetAll();
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public PatientDrugs GetById(int id)
        {
            return ICRUDServices.GetById(id);

        }
        [HttpPut]
        [Route("Update")]
        public bool Update(PatientDrugs t)
        {
            return ICRUDServices.Update(t);

        }
    }
}
