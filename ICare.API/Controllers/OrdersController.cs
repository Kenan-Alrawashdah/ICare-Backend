using ICare.Core.ApiDTO;
using ICare.Core.Data;
using ICare.Core.IServices;
using Microsoft.AspNetCore.Authorization;
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
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IUserServices _userServices;
        private readonly IPatientServices _patientServices;

        public OrdersController(IOrderService orderService,IUserServices userServices,IPatientServices patientServices)
        {
            _orderService = orderService;
            this._userServices = userServices;
            this._patientServices = patientServices;
        }

        [HttpPost]
        [Route("CreateOrder")]
        public async Task<ActionResult<ApiResponse>> CreateOrder(AddOrederApiDTO.Request request)
        {
            var response = new ApiResponse();
            var user = _userServices.GetUser(User);
            var patient = _patientServices.GetPatientByUserId(user.Id);
            var order = new Order
            {
                TotalPrice = request.TotalPrice,
                PatientId = patient.Id,
                LocationId = request.LocationId
            };

            await _orderService.Create(order, request.cartsId);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetPatientOrders")]
        public async Task<ActionResult<PaitentOrderApiDTO.Response>> GetPatientOrders()
        {
            var response = new ApiResponse<IEnumerable<PaitentOrderApiDTO.Response>>();
            var user = _userServices.GetUser(User);
            var patient = _patientServices.GetPatientByUserId(user.Id);
            response.Data =await _orderService.GetPatientOrders(patient.Id);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetOpenOrders")]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetAllOpenOredersApiDTO.Response>>>> GetOpenOrders()
        {
            var response = new ApiResponse<IEnumerable<GetAllOpenOredersApiDTO.Response>>();

            response.Data = await _orderService.GetAllOpenOrders();
            
            return Ok(response);

        }

        [HttpGet]
        [Route("GetOrderDrugs/{id:int}")]
        public async Task<ActionResult<ApiResponse<IEnumerable<OrderDrugsApiDTO.Response>>>> GetOrderDrugs(int id)
        {
            var response = new ApiResponse<IEnumerable<OrderDrugsApiDTO.Response>>();

            response.Data = await _orderService.GetOrderDrugs(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("SetOrderAsCanceled/{id:int}")]
        public ActionResult<ApiResponse> SetOrderAsCanceled(int id)
        {
            var response = new ApiResponse();

            _orderService.SetOrderAsCanceled(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("SetOrderAsPlaced/{id:int}")]
        public ActionResult<ApiResponse> SetOrderAsPlaced(int id)
        {
            var response = new ApiResponse();

            _orderService.SetOrderAsPlaced(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetPlacedOrders")]
        public async Task<ActionResult<ApiResponse<IEnumerable<PlacedOrdersApiDTO.Response>>>> GetPlacedOrders()
        {
            var response = new ApiResponse<IEnumerable<PlacedOrdersApiDTO.Response>>();

            response.Data = await _orderService.GetPlacedOrders();

            return Ok(response); 
        }
    }
}
