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
        private readonly ILocationSevices _locationSevices;
        private readonly IWaterServices _waterServices;

        public PatientController(IPatientServices patientServices, IUserServices userServices, ILocationSevices locationSevices,IWaterServices waterServices)
        {
            this._patientServices = patientServices;
            this._userServices = userServices;
            this._locationSevices = locationSevices;
            this._waterServices = waterServices;
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
            if (drugDoseTimeLsit.Count == 0)
            {
                response.AddError("must have at least on dose time");
                return Ok(response);
            }
            await _patientServices.AddPatientDrugs(patientDrug, drugDoseTimeLsit);

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
            response.Data = new MyDrugsApiDto.Response();
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

            response.Data = await _patientServices.GetDrug(id);

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


        /// <summary>
        /// Add Location page
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        [Route("AddLocation")]
        public ActionResult<ApiResponse> AddLocation(AddLocationApiDTO.Request request)
        {
            var response = new ApiResponse();
            var user = _userServices.GetUser(User);
            var location = new Location
            {
                AddressName = request.AddressName,
                City = request.AddressName,
                PhoneNumber = request.PhoneNumber,
                Street = request.Street,
                Details = request.Details,
                ZipCode = request.ZipCode,
                UserId = user.Id
            };
            _locationSevices.AddLocation(location);
            return Ok(response);
        }


        /// <summary>
        /// Get All locations for the user 
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route("GetUserLocations")]
        public async Task<ActionResult<ApiResponse<IEnumerable<Location>>>> GetUserLocations()
        {
            var user = _userServices.GetUser(User);
            var response = new ApiResponse<IEnumerable<Location>>();

            response.Data = await _locationSevices.GetUserLocations(user.Id);
            return Ok(response);
        }


        /// <summary>
        /// Get Location for Edit page 
        /// </summary>
        /// <param name="id">the id of the location</param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route("GetLocationById/{id:int}")]
        public async Task<ActionResult<ApiResponse<Location>>> GetLocationById(int id)
        {
            var response = new ApiResponse<Location>();
            response.Data = await _locationSevices.GetLocationById(id);
            return Ok(response);

        }

        /// <summary>
        /// Edit location post
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut]
        [Route("EditLocation")]
        public ActionResult<ApiResponse> EditLocation(EditLocationApiDTO.Request request)
        {
            var response = new ApiResponse();
            var user = _userServices.GetUser(User);
            var location = new Location
            {
                Id = request.Id,
                AddressName = request.AddressName,
                City = request.AddressName,
                PhoneNumber = request.PhoneNumber,
                Street = request.Street,
                Details = request.Details,
                ZipCode = request.ZipCode,
            };
            _locationSevices.EditLocation(location);
            return Ok(response);
        }

        /// <summary>
        /// Delete Location by id
        /// </summary>
        /// <param name="id">the id of the location</param>
        /// <returns></returns>
        [Authorize]
        [HttpDelete]
        [Route("DeleteLocation/{id:int}")]
        public ActionResult<ApiResponse> DeleteLocation(int id) 
        {
            var response = new ApiResponse();
           if( _locationSevices.DeleteLocation(id))
            {
                return Ok(response);
            }
            else
            {
                response.AddError("There is something error");
                return Ok(response); 
            }

        }


        /// <summary>
        /// Water Add page ""check the if "From" before "To" else set error
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        [Route("AddWater")]
        public ActionResult<ApiResponse> AddWater(AddWaterApiDTO.Request request)
        {
            var response = new ApiResponse();
            var user = _userServices.GetUser(User);
            var patient = _patientServices.GetPatientByUserId(user.Id);

            if (_waterServices.AddWater(request,patient.Id))
            {
                return Ok(response);
            }
            else
            {
                response.AddError("There is something error");
                return Ok(response);
            }
        }

        /// <summary>
        /// Edit water page 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut]
        [Route("EditWater")]
        public ActionResult<ApiResponse> EditWater(EditWaterApiDTO.Request request)
        {
            var response = new ApiResponse();

            if (_waterServices.EditWater(request))
            {
                return Ok(response);
            }
            else
            {
                response.AddError("There is something error");
                return Ok(response);
            }

        }


        /// <summary>
        /// Delete Water page
        /// </summary>
        /// <param name="id">id of the water recored water to delete</param>
        /// <returns></returns>
        [Authorize]
        [HttpDelete]
        [Route("DeleteWater/{id:int}")]
        public ActionResult<ApiResponse> DeleteWater(int id)
        {
            var response = new ApiResponse(); 
            if(_waterServices.DeleteWater(id))
            {
                return Ok(response);
            }
            else
            {
                response.AddError("There is something error"); 
                return Ok(response);
            }

        }

        /// <summary>
        /// Get Water page 
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route("GetWater")]
        public async Task<ActionResult<ApiResponse<Water>>> GetWater()
        {
            var respnse = new ApiResponse<Water>();
            var user = _userServices.GetUser(User);

            var water = await _waterServices.GetWaterByUserId(user.Id);
            respnse.Data = water;
            return Ok(respnse); 

        }

        

        
    }

    
}
