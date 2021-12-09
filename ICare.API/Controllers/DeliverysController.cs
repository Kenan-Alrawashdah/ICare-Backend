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
    public class DeliverysController : ControllerBase
    {
        private readonly IDeliveryService _deliveryService;
        private readonly IUserServices _userServices;

        public DeliverysController(IDeliveryService deliveryService, IUserServices userServices)
        {
            _deliveryService = deliveryService;
            this._userServices = userServices;
        }

        [HttpGet]
        [Route("getAllOrdersForDelivery")]
        public async Task<ActionResult<ApiResponse<getAllOrdersForDeliveryDTO.Response>>> getAllOrdersForDelivery()
        {

            var response = new ApiResponse<IEnumerable<getAllOrdersForDeliveryDTO.Response>>();
            var request = new getAllOrdersForDeliveryDTO.Request();

            //var user = _userServices.GetUser(User);
            //var Delivery = _deliveryService.GetById(user.Id);

            request.DeliveryId = 1;
            var AllOrdersForDelivery =await _deliveryService.getAllOrdersForDelivery(request);
            if (AllOrdersForDelivery == null)
            {
                response.AddError("No Orders For Display");
                return Ok(response);
            }
            response.Data = new List<getAllOrdersForDeliveryDTO.Response>();
            response.Data = AllOrdersForDelivery;
            return Ok(response);


        }
        //[HttpGet("GetAll")]
        //[ProducesResponseType(typeof(List<Delivery>), StatusCodes.Status200OK)]
        //public List<Delivery> GetAllBook()
        //{
        //    return _deliveryService.GetAll().ToList();
        //}

        //[HttpPost("Add")]
        //[ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        //public bool AddDelivery(Delivery delivery)
        //{
        //    return _deliveryService.Create(delivery);
        //}

        //[HttpDelete("Delete/{deliveryId:int}")]
        //[ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        //public bool DeleteDelivery(int deliveryId)
        //{
        //    return _deliveryService.Delete(deliveryId);
        //}

        //[HttpPut("Update")]
        //[ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        //public bool UpdateDelivery(Delivery delivery)
        //{
        //    return _deliveryService.Update(delivery);
        //}

        [HttpPost("GetById/{deliveryId:int}")]
        [ProducesResponseType(typeof(Delivery), StatusCodes.Status200OK)]
        public Delivery GetDeliveryById(int deliveryId)
        {
            return _deliveryService.GetById(deliveryId);
        }

        [HttpGet]
        [Route("getNumberOfOrdersForDelivery")]
        public async Task<ActionResult<ApiResponse<getNumberOfOrdersForDeliveryDTO.Response>>> getNumberOfOrdersForDelivery()
        {
            var request = new getNumberOfOrdersForDeliveryDTO.Request();
            //var user = _userServices.GetUser(User);
            //var Delivery = _deliveryService.GetById(user.Id);

            request.DeliveryId = 1;
            var response = new ApiResponse<getNumberOfOrdersForDeliveryDTO.Response>();
            var NumberOfOrdersForDelivery = await _deliveryService.getNumberOfOrdersForDelivery(request);
            response.Data = new getNumberOfOrdersForDeliveryDTO.Response();
            response.Data = NumberOfOrdersForDelivery;
            return Ok(response);

        }
        [HttpPatch]
        [Route("TakeOrder")]

        public ActionResult<ApiResponse> TakeOrder(int id)
        {
            var response = new ApiResponse();
            var result = _deliveryService.TakeOrder(id);
            if (result == false)
            {
                response.AddError("Something Wrong");
                return Ok(response);
            }
            return Ok(response);
        }
        [HttpPatch]
        [Route("OrderDeliverd")]

        public ActionResult<ApiResponse> OrderDeliverd(int id)
        {
            var response = new ApiResponse();
            var result = _deliveryService.OrderDeliverd(id);
            if (result == false)
            {
                response.AddError("Something Wrong");
                return Ok(response);
            }
            return Ok(response);

        }
    }
}
