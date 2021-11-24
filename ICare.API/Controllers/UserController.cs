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
        private readonly IPasswordHashingService _passwordHashingService;
        private readonly IJWTService _jWTService;

        public UserController(IUserServices userServices,IFileService fileService, IPasswordHashingService passwordHashingService, IJWTService jWTService)
        {
            this._userServices = userServices;
            this._fileService = fileService;
            this._passwordHashingService = passwordHashingService;
            this._jWTService = jWTService;
        }

        /// <summary>
        /// SignUp Page for Patient
        /// </summary>
        /// <param name="request"></param>
        /// <returns>token</returns>
        [HttpPost]
        [Route("PatientRegistration")]
        public ActionResult<ApiResponse<RegistrationApiDTO.Response>> PatientRegistration(RegistrationApiDTO.Request request)
        {
            var response = new ApiResponse<RegistrationApiDTO.Response>();
            if (_userServices.CheckEmailExist(request.Email))
            {
                response.AddError("The email is already exist");
                return Ok(response);
            }
            var hashedPassword = _passwordHashingService.GetHash(request.Password);
            var passwordForLogin = request.Password;
            request.Password = hashedPassword;
            _userServices.Registration(request);
            //TODO: Return the Token 
            var token = _jWTService.Auth(request.Email, passwordForLogin);
            response.Data = new RegistrationApiDTO.Response();
            response.Data.Token = token;
            return Ok(response);
        }

        /// <summary>
        /// Upload profile image for user
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

        [HttpPost]
        [Route("GetDrugByNameSearch")]
        public ActionResult<ApiResponse<GetBySearchDTO.Response>> GetDrugByNameSearch(GetBySearchDTO.Request request)
        {
            var response = new ApiResponse<IEnumerable<GetBySearchDTO.Response>>();
            var drugList = _userServices.GetDrugByNameSearch(request);
            if (drugList == null)
            {
                response.AddError("No medicine left for sale");
                return Ok(response);
            }
            response.Data = new List<GetBySearchDTO.Response>();
            response.Data = drugList;
            return Ok(response);

        }
        [HttpPost]
        [Route("ForgotPassword")]
        public async Task<ActionResult<ApiResponse>> ForgotPassword(ChangeUserPasswordDTO.Request request)
        {

            var response = new ApiResponse();
            var drugList = _userServices.ForgotPassword(request);
            if (drugList == null)
            {
                response.AddError("This Email Not Exist");
                return Ok(response);
            }
           
            return Ok(response);
        }

        //[HttpPut]
        //[Route("Update")]
        //[ProducesResponseType(type: typeof(bool), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public bool Update(ApplicationUser UserModel)
        //{
        //    return _userServices.Update(UserModel);
        //}

        //[HttpDelete]
        //[Route("Delete/{id}")]
        //[ProducesResponseType(type: typeof(bool), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public bool Delete(int id)
        //{
        //    return _userServices.Delete(id);
        //}

        //[HttpGet]
        //[Route("GetById/{id}")]
        //public ActionResult<ApiResponse<GetUserByIdApiDTO.Response>> GetById(int id)
        //{
        //    var response = new ApiResponse<GetUserByIdApiDTO.Response>();
        //    var user = _userServices.GetById(id); 
        //    if(user == null)
        //    {
        //        response.AddError("No User With this id");
        //        return response; 
        //    }

        //    response.Data = new GetUserByIdApiDTO.Response
        //    {
        //        User = user
        //    };

        //    return Ok(response);
        //}

        //[HttpGet]
        //[Route("GetAll")]
        //public ActionResult<ApiResponse<GetAllUserApiDTO.Response>> GetAll()
        //{
        //    var response = new ApiResponse<GetAllUserApiDTO.Response>();

        //    return Ok(response);
        //}

    }
}
