using ICare.Core.ApiDTO;
using ICare.Core.Data;
using ICare.Core.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ICare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientServices _patientServices;
        private readonly IUserServices _userServices;
        private readonly IFileService _fileService;
        private readonly ILocationSevices _locationSevices;
        private readonly IWaterServices _waterServices;
        private readonly ISubscriptionServices _subscriptionServices;

        public PatientController(IPatientServices patientServices, IUserServices userServices, IFileService fileService, ILocationSevices locationSevices,IWaterServices waterServices , ISubscriptionServices subscriptionServices)
        {
            this._patientServices = patientServices;
            this._userServices = userServices;
            this._locationSevices = locationSevices;
            this._waterServices = waterServices;
            this._subscriptionServices = subscriptionServices;
            this._fileService = fileService;

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

            if (request.drugDoseTime1 != null && request.drugDoseTime1 != "")
            {
                var d = new DrugDoseTime()
                {
                    Time = request.drugDoseTime1
                };
                drugDoseTimeLsit.Add(d);
            }
            if (request.drugDoseTime2 != null && request.drugDoseTime2 != "")
            {
                var d = new DrugDoseTime()
                {
                    Time = request.drugDoseTime2
                };
                drugDoseTimeLsit.Add(d);
            }
            if (request.drugDoseTime3 != null && request.drugDoseTime3 != "")
            {
                var d = new DrugDoseTime()
                {
                    Time = request.drugDoseTime3
                };
                drugDoseTimeLsit.Add(d);
            }
            if (request.drugDoseTime4 != null && request.drugDoseTime4 != "")
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
            response.Data.EndDate2 = response.Data.EndDate?.ToString("yyyy-MM-dd");

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

        [Authorize]
        [HttpPost]
        [Route("InsertPDFData")]
        public async Task<ActionResult<ApiResponse>> InsertPDFData(IFormFile PdfFile)
        {
            var user = _userServices.GetUser(User);
            var patient = _patientServices.GetPatientByUserId(user.Id);
            var fileName = DateTime.Now.ToFileTime().ToString() + ".pdf";
            await _fileService.SaveFile(PdfFile, fileName, "PatientPDFFiles");



            FileStream docStream = new FileStream("wwwroot/Files/PatientPDFFiles/"+ fileName, FileMode.Open, FileAccess.Read);

            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

            PdfLoadedForm form = loadedDocument.Form;

            var request =new InsertPDFDataHealthReportDTO.Request();

            request.CheckUpName = (form.Fields[0] as PdfLoadedTextBoxField).Text;
            request.BloodType = (form.Fields[1] as PdfLoadedTextBoxField).Text ;
            request.BloodSugarLevel = (form.Fields[2] as PdfLoadedTextBoxField).Text ;

            request.CheckUpDate = (form.Fields[3] as PdfLoadedTextBoxField).Text ;


            loadedDocument.Close(true);


            request.PatientId = patient.Id;
            //TODO: change check 
            var response = new ApiResponse();
            var result = _patientServices.InsertPDFData(request);
            if (result == null)
            {
                response.AddError("No Data In Pdf File");
                return Ok(response);
            }

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
                City = request.City,
                PhoneNumber = request.PhoneNumber,
                Street = request.Street,
                Details = request.Details,
                ZipCode = request.ZipCode,
                UserId = user.Id,
                lat = request.Lat,
                lng = request.Lng
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
                lng = request.lng, 
                lat = request.lat
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
        public async Task<ActionResult<ApiResponse<GetWaterApiDTO.Response>>> GetWater()
        {
            var response = new ApiResponse<GetWaterApiDTO.Response>();
            var user = _userServices.GetUser(User);
            var patient = _patientServices.GetPatientByUserId(user.Id);
            var water = await _waterServices.GetPatientWater(patient.Id);
            if(water == null)
            {
                response.AddError("The patient Don't have water notification");
                return Ok(response);
            }
            response.Data = new GetWaterApiDTO.Response();
            response.Data.Id = water.Id;
            response.Data.From = water.From.ToString();
            response.Data.To = water.To.ToString();
            response.Data.Every = water.Every;
            return Ok(response); 

        }



        [Authorize]
        [HttpPost]
        [Route("AddPatientSubscription")]
        public async Task<ActionResult<ApiResponse>> AddPatientSubscription(int subscribeTypeId)
        {
            var respnse = new ApiResponse<AddPatientSubscriptionDTO.Request>();
            var user = _userServices.GetUser(User);
            var patient = _patientServices.GetPatientByUserId(user.Id);

            AddPatientSubscriptionDTO.Request request = new AddPatientSubscriptionDTO.Request();
           
            request.SubscribeTypeId = subscribeTypeId;
            request.PatientId = patient.Id;
            var result = await _subscriptionServices.AddPatientSubscription(request);

            return Ok(respnse);

        }
        /// <summary>
        /// Delete Patient Subscription
        /// </summary>
        /// <param name="id">id of the patient recored to delete</param>
        /// <returns></returns>
        [Authorize]
        [HttpDelete]
        [Route("DeletePatientSubscription/{id:int}")]
        public async Task<ActionResult<ApiResponse>> DeletePatientSubscription(int id)
        {
            var response = new ApiResponse();
            if (await _subscriptionServices.DeletePatientSubscription(id))
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
        /// Get Subscription By Patient Id
        /// </summary>
        /// <param name="id">id of the patient recored to Get</param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route("GetByPatientId/{id:int}")]
        public async Task<ActionResult<ApiResponse>> GetByPatientId(int id)
        {
            var response = new ApiResponse<Subscription>();

            var result = await _subscriptionServices.GetByPatientId(id);
            response.Data = result;
            if (result != null)
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
        /// Update Patient Subscription 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut]
        [Route("UpdatePatientSubscription")]
        public async Task<ActionResult<ApiResponse>> UpdatePatientSubscription(UpdatePatientSubscriptionDTO.Request request)
        {
            var response = new ApiResponse();

            if (await _subscriptionServices.UpdatePatientSubscription(request))
            {
                return Ok(response);
            }
            else
            {
                response.AddError("There is something error");
                return Ok(response);
            }

        }

        [HttpGet]
        [Route("GetAllPatientSubscription")]
        public async Task<ActionResult<ApiResponse>> GetAllPatientSubscription()
        {
            var response = new ApiResponse<IEnumerable<GetAllPatientSubscriptionDTO>>();
            var result = await _subscriptionServices.GetAllPatientSubscription();
            response.Data = result;
            if (result != null)
            {
                return Ok(response);
            }
            else
            {
                response.AddError("There is No Patient Subscription");
                return Ok(response);
            }

        }
        [Authorize]
        [HttpPost]
        [Route("SubscriptionPayment")]
        public async Task<ActionResult<ApiResponse>> SubscriptionPayment(int subscribeTypeId, SubscriptionPaymentDTO.Request request)
        {
            var response = new ApiResponse<Payment>();
            
            var result = await _subscriptionServices.SubscriptionPayment(request);
            response.Data = result;
            if (result != null)
            {
                return Ok(response);
                AddPatientSubscription(subscribeTypeId);
            }
            else
            {
                response.AddError("There is something error");
                return Ok(response);
            }

        }



    }


}
