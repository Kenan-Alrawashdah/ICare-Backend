using ICare.Core.ApiDTO;
using ICare.Core.Data;
using ICare.Core.IServices;
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

        public SubscriptionController(ISubscriptionTypeServices subscriptionTypeServices)
        {
            this._SubscriptionTypeServices = subscriptionTypeServices;
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

    }
}
