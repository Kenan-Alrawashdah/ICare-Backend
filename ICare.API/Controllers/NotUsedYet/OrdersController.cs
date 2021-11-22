//using ICare.Core.Data;
//using ICare.Core.IServices;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace ICare.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class OrdersController : ControllerBase
//    {
//        private readonly IOrderService _orderService;

//        public OrdersController(IOrderService orderService)
//        {
//            _orderService = orderService;
//        }

//        [HttpGet("GetAll")]
//        [ProducesResponseType(typeof(List<Order>), StatusCodes.Status200OK)]
//        public List<Order> GetAllOrder()
//        {
//            return _orderService.GetAll().ToList();
//        }

//        [HttpPost("Add")]
//        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
//        public bool AddOrder(Order order)
//        {
//            return _orderService.Create(order);
//        }

//        [HttpDelete("Delete/{orderId:int}")]
//        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
//        public bool DeleteOrder(int orderId)
//        {
//            return _orderService.Delete(orderId);
//        }

//        [HttpPut("Update")]
//        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
//        public bool UpdateOrder(Order order)
//        {
//            return _orderService.Update(order);
//        }

//        [HttpPost("GetById/{orderId:int}")]
//        [ProducesResponseType(typeof(Order), StatusCodes.Status200OK)]
//        public Order GetOrderById(int orderId)
//        {
//            return _orderService.GetById(orderId);
//        }
//    }
//}
