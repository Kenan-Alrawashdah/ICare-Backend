using ICare.Core.Data;
using ICare.Core.IRepository;
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
        private readonly IPatientDrugsRepository _patientDrugsServices;
        public PatientDrugsController(IPatientDrugsRepository ICRUDServices)
        {
            this._patientDrugsServices = ICRUDServices;
        }
        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(typeof(PatientDrugs), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool Create(PatientDrugs t)
        {
            return _patientDrugsServices.Create(t);
        }
        [HttpDelete, Route("delete/{id}")]
        public bool Delete(int id)
        {
            return _patientDrugsServices.Delete(id);
        }
        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<PatientDrugs> GetAll()
        {
            return _patientDrugsServices.GetAll();
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public PatientDrugs GetById(int id)
        {
            return _patientDrugsServices.GetById(id);

        }
        [HttpPut]
        [Route("Update")]
        public bool Update(PatientDrugs t)
        {
            return _patientDrugsServices.Update(t);

        }
    }
}
