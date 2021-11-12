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
        private readonly IFileService _fileService;

        public UserController(IUserServices userServices,IFileService fileService)
        {
            this._userServices = userServices;
            this._fileService = fileService;
        }

        /// <summary>
        /// SignUp Page
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("PatientRegistration")]
        public ActionResult<ApiResponse> PatientRegistration(RegistrationApiDTO.Request request)
        {
            var response = new ApiResponse();
            if (_userServices.CheckEmailExist(request.Email))
            {
                response.AddError("The email is already exist");
                return Ok(response);
            }
            _userServices.Registration(request);
            //TODO: Return the Token 
            return Ok(response);
        }

        /// <summary>
        /// Upload profile image 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [Route("UploadProilePicture")]
        public async Task< ActionResult<ApiResponse>> UploadProilePicture(IFormFile image)
        {
            var user = _userServices.GetUser(User);
            var response = new ApiResponse();
            if(!_fileService.IsPicture(image.FileName))
            {
                response.AddError("The file must be an image");
                return Ok(response);
            }
            if(_fileService.CheckPictureSizeInMB(image.Length,2))
            {
                response.AddError("The file must be less than 2 MB");
                return Ok(response);
            }
            var imageName = _fileService.GenerateFileName(image.FileName);
            await  _fileService.SavePic(image, imageName);
            _userServices.AddOrUpdateProfilePicture(imageName, user.Id);
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
