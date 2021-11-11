using ICare.Core.ApiDTO;
using ICare.Core.Data;
using ICare.Core.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        public ActionResult<ApiResponse> Create(ApplicationUser UserModel)
        {
            var response = new ApiResponse();
            if (_userServices.CheckEmailExist(UserModel.Email))
            {
                response.AddError("The email is already exist");
                return Ok(response);
            }
            _userServices.Create(UserModel);
            return Ok(response);
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
        public ActionResult<ApiResponse<GetUserByIdApiDTO.Response>> GetById(int id)
        {
            var response = new ApiResponse<GetUserByIdApiDTO.Response>();
            var user = _userServices.GetById(id); 
            if(user == null)
            {
                response.AddError("No User With this id");
                return response; 
            }

            response.Data = new GetUserByIdApiDTO.Response
            {
                User = user
            };
            
            return Ok(response);
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult<ApiResponse<GetAllUserApiDTO.Response>> GetAll()
        {
            var response = new ApiResponse<GetAllUserApiDTO.Response>();

            return Ok(response);
        }

    }
}
