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
    public class UserRolesController : ControllerBase
    {
        private readonly IUserRolesServices _userRolesServices;

        public UserRolesController(IUserRolesServices userServices)
        {
            this._userRolesServices = userServices;
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(type: typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool Create(UserRoles UserRolesModel)
        {
            return _userRolesServices.Create(UserRolesModel);
        }

        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(type: typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool Update(UserRoles UserRolesModel)
        {
            return _userRolesServices.Update(UserRolesModel);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        [ProducesResponseType(type: typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool Delete(int id)
        {
            return _userRolesServices.Delete(id);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        [ProducesResponseType(type: typeof(UserRoles), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public UserRoles  GetById(int id)
        {
            return _userRolesServices.GetById(id);
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(type: typeof(IEnumerable<UserRoles>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IEnumerable<UserRoles> GetAll()
        {
            return _userRolesServices.GetAll();
        }
    }
}
