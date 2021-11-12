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
    public class UserLoginsController : ControllerBase
    {
        private readonly IUserLoginsServices _userLoginsServices;

        public UserLoginsController(IUserLoginsServices userServices)
        {
            this._userLoginsServices = userServices;
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(type: typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool Create(UserLogins userLoginssModel)
        {
            return _userLoginsServices.Create(userLoginssModel);
        }

        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(type: typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool Update(UserLogins userLoginssModel)
        {
            return _userLoginsServices.Update(userLoginssModel);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        [ProducesResponseType(type: typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool Delete(int id)
        {
            return _userLoginsServices.Delete(id);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        [ProducesResponseType(type: typeof(UserLogins), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public UserLogins GetById(int id)
        {
            return _userLoginsServices.GetById(id);
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(type: typeof(IEnumerable<UserLogins>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IEnumerable<UserLogins> GetAll()
        {
            return _userLoginsServices.GetAll();
        }
    }
}
