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
    public class OrderDrugsController : ControllerBase
    {
        private readonly IOrderDrugsService _orderDrugsService;

        public OrderDrugsController(IOrderDrugsService orderDrugsService)
        {
            _orderDrugsService = orderDrugsService;
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(List<OrderDrugs>), StatusCodes.Status200OK)]
        public List<OrderDrugs> GetAllDrugCategory()
        {
            return _orderDrugsService.GetAll().ToList();
        }

        [HttpPost("Add")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public bool AddOrderDrugs(OrderDrugs orderDrugs)
        {
            return _orderDrugsService.Create(orderDrugs);
        }

        [HttpDelete("Delete/{orderDrugsId:int}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public bool DeleteOrderDrugs(int orderDrugsId)
        {
            return _orderDrugsService.Delete(orderDrugsId);
        }

        [HttpPut("Update")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public bool UpdateOrderDrugs(OrderDrugs orderDrugs)
        {
            return _orderDrugsService.Update(orderDrugs);
        }

        [HttpPost("GetById/{orderDrugsId:int}")]
        [ProducesResponseType(typeof(OrderDrugs), StatusCodes.Status200OK)]
        public OrderDrugs GetOrderDrugsById(int orderDrugsId)
        {
            return _orderDrugsService.GetById(orderDrugsId);
        }
    }
}
