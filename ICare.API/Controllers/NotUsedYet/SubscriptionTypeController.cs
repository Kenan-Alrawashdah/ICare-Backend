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
//    public class SubscriptionTypeController : ControllerBase
//    {
//        private readonly ISubscriptionTypeServices _SubscriptionTypeServices;

//        public SubscriptionTypeController(ISubscriptionTypeServices SubscriptionTypeServices)
//        {
//            this._SubscriptionTypeServices = SubscriptionTypeServices;
//        }
//        [HttpPost]
//        [Route("Create")]
//        [ProducesResponseType(type: typeof(bool), StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        public bool Create(SubscribeType subscribeType)
//        {
//            return _SubscriptionTypeServices.Create(subscribeType);
//        }

//        [HttpPut]
//        [Route("Update")]
//        [ProducesResponseType(type: typeof(bool), StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        public bool Update(SubscribeType subscribeType)
//        {
//            return _SubscriptionTypeServices.Update(subscribeType);
//        }

//        [HttpDelete]
//        [Route("Delete/{id}")]
//        [ProducesResponseType(type: typeof(bool), StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        public bool Delete(int id)
//        {
//            return _SubscriptionTypeServices.Delete(id);
//        }

//        [HttpGet]
//        [Route("GetById/{id}")]
//        [ProducesResponseType(type: typeof(SubscribeType), StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        public SubscribeType GetById(int id)
//        {
//            return _SubscriptionTypeServices.GetById(id);
//        }

//        [HttpGet]
//        [Route("GetAll")]
//        [ProducesResponseType(type: typeof(IEnumerable<SubscribeType>), StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        public IEnumerable<SubscribeType> GetAll()
//        {
//            return _SubscriptionTypeServices.GetAll();
//        }
//    }
//}
