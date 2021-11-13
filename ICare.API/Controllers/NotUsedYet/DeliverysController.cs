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
//    public class DeliverysController : ControllerBase
//    {
//        private readonly IDeliveryService _deliveryService;

//        public DeliverysController(IDeliveryService deliveryService)
//        {
//            _deliveryService = deliveryService;
//        }


//        [HttpGet("GetAll")]
//        [ProducesResponseType(typeof(List<Delivery>), StatusCodes.Status200OK)]
//        public List<Delivery> GetAllBook()
//        {
//            return _deliveryService.GetAll().ToList();
//        }

//        [HttpPost("Add")]
//        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
//        public bool AddDelivery(Delivery delivery)
//        {
//            return _deliveryService.Create(delivery);
//        }

//        [HttpDelete("Delete/{deliveryId:int}")]
//        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
//        public bool DeleteDelivery(int deliveryId)
//        {
//            return _deliveryService.Delete(deliveryId);
//        }

//        [HttpPut("Update")]
//        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
//        public bool UpdateDelivery(Delivery delivery)
//        {
//            return _deliveryService.Update(delivery);
//        }

//        [HttpPost("GetById/{deliveryId:int}")]
//        [ProducesResponseType(typeof(Delivery), StatusCodes.Status200OK)]
//        public Delivery GetDeliveryById(int deliveryId)
//        {
//            return _deliveryService.GetById(deliveryId);
//        }
//    }
//}
