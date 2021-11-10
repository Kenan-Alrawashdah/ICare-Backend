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
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            this._userServices = userServices;
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(type: typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool Create(ApplicationUser UserModel)
        {
            return _userServices.Create(UserModel);
        }

        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(type: typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool Update(ApplicationUser UserModel)
        {
            return _userServices.Update(UserModel);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        [ProducesResponseType(type: typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool Delete(int id)
        {
            return _userServices.Delete(id);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        [ProducesResponseType(type: typeof(ApplicationUser), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ApplicationUser GetById(int id)
        {
            return _userServices.GetById(id);
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(type: typeof(IEnumerable<ApplicationUser>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IEnumerable<ApplicationUser> GetAll()
        {
            return _userServices.GetAll();
        }

    }
}
