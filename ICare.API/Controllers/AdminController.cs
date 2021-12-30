using ICare.Core.ApiDTO;
using ICare.Core.ApiDTO.Admin.Role;
using ICare.Core.Data;
using ICare.Core.IServices;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class AdminController : ControllerBase
    {
        private readonly IDrugCategoryService _drugCategoryService;
        private readonly IDrugService _drugService;
        private readonly IFileService _fileService;
        private readonly IEmployessServices _employessServices;
        private readonly IOrderService _orderService;
        private readonly IUserServices _userServices;
        private readonly IDeliveryService _deliveryService;
        private readonly IPasswordHashingService _passwordHashingService;

        public AdminController(IDrugCategoryService drugCategoryService,
                               IDrugService drugService,
                               IFileService fileService,
                               IEmployessServices employessServices,
                               IOrderService orderService,
                               IUserServices userServices,
                               IDeliveryService deliveryService,
                               IPasswordHashingService passwordHashingService)
        {
            this._drugCategoryService = drugCategoryService;
            this._drugService = drugService;
            this._fileService = fileService;
            this._employessServices = employessServices;
            this._orderService = orderService;
            this._userServices = userServices;
            this._deliveryService = deliveryService;
            this._passwordHashingService = passwordHashingService;
        }

        [HttpGet]
        [Route("GetPaymentOrders")]
        public ActionResult<ApiResponse<GetPaymentOrdersDTO.Response>> GetPaymentOrders()
        {

            var response = new ApiResponse<IEnumerable<GetPaymentOrdersDTO.Response>>();
            response.Data = _orderService.GetPaymentOrders();
            if (response.Data == null)
            {
                response.AddError("no Testimonial for display");
                return Ok(response);
            }
            return Ok(response);


        }

        [HttpDelete]
        [Route("DeleteUser/{id:int}")]
        public ActionResult<ApiResponse> DeleteUser(int id)
        {
            var response = new ApiResponse();
            _userServices.Delete(id);

            return Ok(response); 
        }

        [HttpGet]
        [Route("GetAllDeliveries")]
        public async Task<ActionResult<ApiResponse<IEnumerable<ApplicationUser>>>> GetAllDeliveries()
        {
            var response = new ApiResponse<IEnumerable<ApplicationUser>>();

            response.Data = await _deliveryService.GetAllDeliveries();

            return Ok(response); 
        }

        [HttpPost]
        [Route("SearchInByDatePaymentOrders")]
        public ActionResult<ApiResponse<GetPaymentOrdersDTO.Response>> SearchInByDatePaymentOrders(GetPaymentOrdersDTO.Resqust resqust )
        {

            var response = new ApiResponse<IEnumerable<GetPaymentOrdersDTO.Response>>();
            response.Data = _orderService.SearchInByDatePaymentOrders(resqust);
            if (response.Data == null)
            {
                response.AddError("no Testimonial for display");
                return Ok(response);
            }
            return Ok(response);


        }
        [HttpGet]
        [Route("GetPatientStatsLast5Year")]
        public ActionResult<ApiResponse<GetPatientStatsLast5YearDTO>> GetPatientStatsLast5Year()
        {

            var response = new ApiResponse<IEnumerable<GetPatientStatsLast5YearDTO>>();
            response.Data = _userServices.GetPatientStatsLast5Year();
            if (response.Data == null)
            {
                response.AddError("No Data for display");
                return Ok(response);
            }
            return Ok(response);


        }
        [HttpGet]
        [Route("GetSalesStatsLast5Year")]
        public ActionResult<ApiResponse<GetSalesStatsLast5YearDTO>> GetSalesStatsLast5Year()
        {

            var response = new ApiResponse<IEnumerable<GetSalesStatsLast5YearDTO>>();
            response.Data = _orderService.GetSalesStatsLast5Year();
            if (response.Data == null)
            {
                response.AddError("No Data for display");
                return Ok(response);
            }
            return Ok(response);


        }
        #region Drug Category
        /// <summary>
        /// get all categories
        /// </summary>
        /// <returns>List of Categories</returns>
        [HttpGet]
        [Route("Category/GetAllDrugCategories")]
        public ActionResult<ApiResponse<GetAllCategoryApiDto.Response>> GetAllDrugCategory()
        {
            var response = new ApiResponse<GetAllCategoryApiDto.Response>();
            response.Data = new GetAllCategoryApiDto.Response();

            response.Data.categories = _drugCategoryService.GetAll()
                .Select(dc => new GetAllCategoryApiDto.CategoryModel
                {
                    id= dc.Id,
                    Name = dc.Name,
                    ImagePath = dc.PicturePath
                }).ToList();

            return Ok(response);
        }

        /// <summary>
        /// Add new category
        /// </summary>
        /// <param name="image">The image of the category</param>
        /// <param name="name">The name of the category</param>
        /// <returns>bool</returns>
        [HttpPost]
        [Route("Category/AddCategory")]
        public async Task<ActionResult<ApiResponse>> AddCategory(IFormFile image, [FromForm] string name)
        {
            var response = new ApiResponse();

            if (!_fileService.IsPicture(image.FileName))
            {
                response.AddError("The file must be an image");
                return Ok(response);
            }
            if (_fileService.CheckPictureSizeInMB(image.Length, 2))
            {
                response.AddError("The file must be less than 2 MB");
                return Ok(response);
            }
            var imageName = _fileService.GenerateFileName(image.FileName);
            await _fileService.SavePic(image, imageName);


            var drugCategory = new DrugCategory
            {
                Name = name,
                PicturePath = imageName
            };

            _drugCategoryService.Create(drugCategory);

            return Ok(response);
        }


        /// <summary>
        /// Delete category by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        [HttpDelete]
        [Route("Category/Delete/{id}")]
        public ActionResult<ApiResponse> DeleteDrugCategory(int id)
        {
            var response = new ApiResponse();
            if(!_drugCategoryService.Delete(id))
            {
                response.AddError("There is something error");
                return Ok(response);
            }
            return Ok(response);
        }


        /// <summary>
        /// Update Category
        /// </summary>
        /// <param name="id">The id of the category</param>
        /// <param name="image">the image of the category</param>
        /// <param name="name">the name of the category</param>
        /// <returns>bool</returns>
        [HttpPut]
        [Route("Category/Update")]
        public async  Task<ActionResult<ApiResponse>> UpdateDrugCategory([FromForm]int id,IFormFile image, [FromForm] string name)
        {
            var response = new ApiResponse();
            var drugCategory = new DrugCategory()
            {
                Id = id,
                Name = name,
            };
            if(image != null)
            {
                if (!_fileService.IsPicture(image.FileName))
                {
                    response.AddError("The file must be an image");
                    return Ok(response);
                }
                if (_fileService.CheckPictureSizeInMB(image.Length, 2))
                {
                    response.AddError("The file must be less than 2 MB");
                    return Ok(response);
                }
                var imageName = _fileService.GenerateFileName(image.FileName);
                await _fileService.SavePic(image, imageName);
                drugCategory.PicturePath = imageName;
            }
          

            _drugCategoryService.Update(drugCategory);

            return Ok(response);
        }


        /// <summary>
        /// Get category by id
        /// </summary>
        /// <param name="id">The id of the category</param>
        /// <returns>Category</returns>
        [HttpGet("Category/GetById/{id}")]
        public ActionResult<ApiResponse<GetCategoryByIdApiDTO.Response>> GetDrugCategoryById(int id)
        {
            var response = new ApiResponse<GetCategoryByIdApiDTO.Response>();
            var category = _drugCategoryService.GetById(id);
     
            if (category == null)
            {
                response.AddError("There is no Category with this id");
                return Ok(response);
            }
            response.Data = new GetCategoryByIdApiDTO.Response()
            {
                id = category.Id,
                imagePath = category.PicturePath,
                name = category.Name
            };
        
            return Ok(response);
        }

        [HttpPost]
        [Route("CreateDelivery")]
        public ActionResult<ApiResponse> CreateDelivery(CreateDeliveryApiDTO.Request  request)
        {
            var response = new ApiResponse();
            var exist = _userServices.CheckEmailExist(request.Email); 
            if(exist)
            {
                response.AddError("The email is already used");
                return Ok(response); 
            }


            var hashedPassword = _passwordHashingService.GetHash(request.Password);
            request.Password = hashedPassword;
            _deliveryService.RegistrationDelivery(request);

            return Ok(response);
        }

        [HttpGet]
        [Route("Role/GetAllRoles")]
        public ActionResult<ApiResponse<GetRolesDTO.Response>> GetAllRoles()
        {
            var response = new ApiResponse<List<GetRolesDTO.Response>>();
           // response.Data = new GetRolesDTO.Response();

            response.Data = _employessServices.GetAllRoles()
                .Select(dc => new GetRolesDTO.Response
                {
                    Id = dc.Id,
                    Name = dc.Name,
                   
                }).ToList();

            return Ok(response);
        }
        #endregion


        #region Drug

        //public ActionResult<ApiResponse<AddDrugToShopApiDTO.Response>> AddDrugToShop(AddDrugToShopApiDTO.Resqust resqust)
        //{
        //    var response = new ApiResponse<AddDrugToShopApiDTO.Response>();

        //    if (resqust.Name == null)
        //    {
        //        response.AddError("the drug must have a name");
        //        return Ok(response);
        //    }


        //    var drug = new Drug
        //    {
        //        DrugCategoryId = resqust.DrugCategoryId,
        //        Name = resqust.Name,
        //        Price = resqust.Price,
        //        PicturePath = resqust.PicturePath
        //    };


        //    _drugService.Create(drug);
        //    response.Data =new AddDrugToShopApiDTO.Response();



        //    return Ok(response);
        //}


        #endregion




    }
}
