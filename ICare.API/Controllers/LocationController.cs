using ICare.Core.ApiDTO;
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
    public class LocationController : ControllerBase
    {
        private readonly ILocationSevices _locationSevices;
        private readonly IUserServices _userServices;

        public LocationController(ILocationSevices locationSevices, IUserServices userServices)
        {
            this._locationSevices = locationSevices;
            this._userServices = userServices;
        }

        [HttpGet]
        [Route("GetLocationByOrderId")]
        public async Task<ActionResult<ApiResponse<Location>>> GetLocationByOrderId(int OrderId)

        {
            var response = new ApiResponse<Location>();
            response.Data = new Location();
            response.Data = await _locationSevices.GetLocationByOrderId(OrderId);

            return Ok(response);

        }
    }
}
