using ICare.Core.ApiDTO;
using ICare.Core.Data;
using ICare.Core.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionTypeServices _SubscriptionTypeServices;
        private readonly ISubscriptionServices _subscriptionServices;
        private readonly IUserServices _userServices;
        private readonly IPatientServices _patientServices;

        public SubscriptionController(ISubscriptionTypeServices subscriptionTypeServices,ISubscriptionServices subscriptionServices, IUserServices userServices, IPatientServices patientServices)
        {
            this._SubscriptionTypeServices = subscriptionTypeServices;
            this._subscriptionServices = subscriptionServices;
            this._userServices = userServices;
            this._patientServices = patientServices;
        }

        [HttpGet]
        [Route("GetTypes")]
        public async Task<ActionResult<ApiResponse<IEnumerable<SubscribeType>>>> GetTypes()
        {
            var response = new ApiResponse<IEnumerable<SubscribeType>>();

            response.Data = await _SubscriptionTypeServices.GetAll();

            return Ok(response); 
        }

        [HttpGet]
        [Route("GetSubscriptionById/{id:int}")]
        public async Task<ActionResult<ApiResponse<SubscribeType>>>  GetSubscriptionById(int id)
        {
            var response = new ApiResponse<SubscribeType>();

            response.Data = await _SubscriptionTypeServices.GetById(id); 

            return Ok(response); 

        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<ApiResponse<IEnumerable<SubscribeType>>>> GetAll()
        {
            var response = new ApiResponse<IEnumerable<SubscribeType>>();

            response.Data = await _subscriptionServices.GetAll(); 

            return Ok(response); 

        }

        [HttpGet]
        [Route("Subscribe/{id:int}")]
        [Authorize]
        public ActionResult<ApiResponse> Subscribe(int id)
        {
            var response = new ApiResponse();
            var user = _userServices.GetUser(User);
            var patient = _patientServices.GetPatientByUserId(user.Id);


            _subscriptionServices.SubscriptionInsert(patient.Id, id); 

            return Ok(response);
        }

        [HttpPut]
        [Route("EditSubscription")]
        public ActionResult<ApiResponse> EditSubscription(SubscribeType subscribeType)
        {
            var response = new ApiResponse();
            _SubscriptionTypeServices.EditSubscribeType(subscribeType);

            return Ok(response);


        }

    }
}
