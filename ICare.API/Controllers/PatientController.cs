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

        [Authorize]
        [HttpPost]
        [Route("AddPatientDrug")]
        public async Task<ActionResult<ApiResponse>> AddPatientDrug(AddpatientDrugApiDTO.Request request)
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
            if(drugDoseTimeLsit.Count == 0)
            {
                response.AddError("must have at least on dose time");
                return Ok(response);
            }
          await  _patientServices.AddPatientDrugs(patientDrug, drugDoseTimeLsit);

            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        [Route("MyDrugs")]
        public async Task<ActionResult<ApiResponse<MyDrugsApiDto.Response>>> MyDrugs()
        {
            var user = _userServices.GetUser(User);
            var patient = _patientServices.GetPatientByUserId(user.Id); 

            var response = new ApiResponse<MyDrugsApiDto.Response>();
            response.Data =new MyDrugsApiDto.Response();
            response.Data.MyDrugs = await _patientServices.GetMyDrugs(patient.Id);

            return Ok(response);

        }

        /// <summary>
        /// Edit drug get page 
        /// </summary>
        /// <param name="id">the id of the drug</param>
        /// <returns></returns>
        [HttpGet]
        [Route("EditDrug/{id:int}")]
        public async Task<ActionResult<ApiResponse<EditDrugApiDTO.Response>>> EditDrug(int id)
        {
            var response = new ApiResponse<EditDrugApiDTO.Response>();
            response.Data = new EditDrugApiDTO.Response();

            response.Data =await _patientServices.GetDrug(id);

            return Ok(response);
        }


        /// <summary>
        /// Edit drug post method 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        [Route("EditDrug")]
        public async Task<ActionResult<ApiResponse>> EditDrug(EditDrugApiDTO.Request request)
        {
            var user = _userServices.GetUser(User);
            var patient = _patientServices.GetPatientByUserId(user.Id);
            var response = new ApiResponse();
            var patientDrug = new PatientDrugs()
            {
                Id = request.Id,
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
            if (drugDoseTimeLsit.Count == 0)
            {
                response.AddError("must have at least on dose time");
                return Ok(response);
            }
            await _patientServices.EditPatientDrugs(patientDrug, drugDoseTimeLsit);

            return Ok(response);

        }

    }
}
