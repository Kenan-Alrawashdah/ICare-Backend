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
    public class PatientController : ControllerBase
    {
        private readonly IPatientServices _patientServices;

        public PatientController(IPatientServices patientServices)
        {
            this._patientServices = patientServices;
        }
        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(type: typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool Create(Patient patient)
        {
            return _patientServices.Create(patient);
        }

        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(type: typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool Update(Patient patient)
        {
            return _patientServices.Update(patient);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        [ProducesResponseType(type: typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool Delete(int id)
        {
            return _patientServices.Delete(id);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        [ProducesResponseType(type: typeof(Patient), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Patient GetById(int id)
        {
            return _patientServices.GetById(id);
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(type: typeof(IEnumerable<Patient>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IEnumerable<Patient> GetAll()
        {
            return _patientServices.GetAll();
        }

    }
}
