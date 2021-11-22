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
//    public class NotificationTypesController : ControllerBase
//    {
//        private readonly INotificationTypesServices _NotificationTypesServices;

//        public NotificationTypesController(INotificationTypesServices NotificationTypesServices)
//        {
//            this._NotificationTypesServices = NotificationTypesServices;
//        }
//        [HttpPost]
//        [Route("Create")]
//        [ProducesResponseType(type: typeof(bool), StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        public bool Create(NotificationTypes notificationTypes)
//        {
//            return _NotificationTypesServices.Create(notificationTypes);
//        }

//        [HttpPut]
//        [Route("Update")]
//        [ProducesResponseType(type: typeof(bool), StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        public bool Update(NotificationTypes notificationTypes)
//        {
//            return _NotificationTypesServices.Update(notificationTypes);
//        }

//        [HttpDelete]
//        [Route("Delete/{id}")]
//        [ProducesResponseType(type: typeof(bool), StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        public bool Delete(int id)
//        {
//            return _NotificationTypesServices.Delete(id);
//        }

//        [HttpGet]
//        [Route("GetById/{id}")]
//        [ProducesResponseType(type: typeof(NotificationTypes), StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        public NotificationTypes GetById(int id)
//        {
//            return _NotificationTypesServices.GetById(id);
//        }

//        [HttpGet]
//        [Route("GetAll")]
//        [ProducesResponseType(type: typeof(IEnumerable<NotificationTypes>), StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        public IEnumerable<NotificationTypes> GetAll()
//        {
//            return _NotificationTypesServices.GetAll();
//        }
//    }
//}
