using ICare.Core.ApiDTO;
using ICare.Core.Data;
using ICare.Core.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Patient")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientServices _patientServices;
        private readonly IUserServices _userServices;

        public PatientController(IPatientServices patientServices, IUserServices userServices)
        {
            this._patientServices = patientServices;
            this._userServices = userServices;
        }

        [HttpPost]
        [Route("AddPatientDrug")]
        public async Task< ActionResult<ApiResponse>> AddPatientDrug(AddpatientDrugApiDTO.Request request)
        {
            var user = _userServices.GetUser(User);
            var patient = _patientServices.GetPatientByUserId(user.Id);
            var response = new ApiResponse();
            var patientDrug = new PatientDrugs()
            {
                DrugName = request.DrugName,
                EndDate = request.EndDate,
                PatientId = patient.Id
            };
            List<DrugDoseTime> drugDoseTimeLsit = new List<DrugDoseTime>();

            if (request.drugDoseTime1 != null)
            {
                var d = new DrugDoseTime()
                {
                    Time = request.drugDoseTime1
                };
                drugDoseTimeLsit.Add(d);
            }
            if (request.drugDoseTime2 != null)
            {
                var d = new DrugDoseTime()
                {
                    Time = request.drugDoseTime2
                };
                drugDoseTimeLsit.Add(d);
            }
            if (request.drugDoseTime3 != null)
            {
                var d = new DrugDoseTime()
                {
                    Time = request.drugDoseTime3
                };
                drugDoseTimeLsit.Add(d);
            }
            if (request.drugDoseTime4 != null)
            {
                var d = new DrugDoseTime()
                {
                    Time = request.drugDoseTime4
                };
                drugDoseTimeLsit.Add(d);
            }

          await  _patientServices.AddPatientDrugs(patientDrug, drugDoseTimeLsit);

            return Ok(response);
        }







    }
}
