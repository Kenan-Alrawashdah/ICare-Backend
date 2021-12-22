using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICare.Core.ApiDTO;
using ICare.Core.ApiDTO.Drug;
using ICare.Core.Data;
using ICare.Core.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ICare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugsController : ControllerBase
    {
        private readonly IDrugService _drugService;
        private readonly IFileService _fileService;

        public DrugsController(IDrugService drugService,IFileService fileService)
        {
            _drugService = drugService;
            this._fileService = fileService;
        }


        [HttpPost]
        [Route("AddDrug")]
        public async Task<ActionResult<ApiResponse>> AddDrug([FromForm]AddDrugApiDTO.Request request)
        {
            var response = new ApiResponse();

            if (!_fileService.IsPicture(request.image.FileName))
            {
                response.AddError("The file must be an image");
                return Ok(response);
            }
            if (_fileService.CheckPictureSizeInMB(request.image.Length, 2))
            {
                response.AddError("The file must be less than 2 MB");
                return Ok(response);
            }
            var imageName = _fileService.GenerateFileName(request.image.FileName);
            await _fileService.SavePic(request.image, imageName);

            var drug = new Drug()
            {
                DrugCategoryId = request.DrugCategoryId,
                Name = request.Name,
                Price = request.Price,
                PicturePath = imageName,
                Brand = request.Brand,
                AvailableQuantity = request.AvailableQuantity,
                Description = request.Description
            };

            _drugService.Create(drug);

            return response;
        }
        
        [HttpGet]
        [Route("GetDrugById/{id:int}")]
        public async Task<ActionResult<ApiResponse<GetDrugByIdApiDTO.Response>>> GetDrugById(int id)
        {
            var response = new ApiResponse<GetDrugByIdApiDTO.Response>();
            response.Data = new GetDrugByIdApiDTO.Response();

            response.Data = await _drugService.GetById(id); 

            return response;
        }


        [HttpGet]
        [Route("GetCategoryDrugs/{id:int}")]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetCategoryDrugsApiDTO.Response>>>> GetCategoryDrugs(int id)
        {
            var response = new ApiResponse<IEnumerable<GetCategoryDrugsApiDTO.Response>>();

            response.Data = await _drugService.GetCategoryDrugs(id);

            return response;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetAllDrugsApiDTO.Response>>>> GetAll()
        {
            var response = new ApiResponse<IEnumerable<GetAllDrugsApiDTO.Response>>();
            response.Data = await _drugService.GetAll();

            return Ok(response);

        }

        [HttpPut]
        [Route("AddQuantity")]
        public ActionResult<ApiResponse> AddQuantity(AddQuantityApiDTO.Request request)
        {
            var response = new ApiResponse();

            _drugService.AddToQuantity(request.DrugId, request.Quantity);

            return Ok(response); 
        }

        [HttpPut]
        [Route("EditDrug")]
        public async  Task<ActionResult<ApiResponse>> EditDrug([FromForm] UpdateDrugApiDTO.Request request)
        {
            var response = new ApiResponse();
            var drug = new Drug
            {
                Id = request.Id,
                Name = request.Name,
                Price = request.Price,
                Brand = request.Brand,
                AvailableQuantity = request.AvailableQuantity,
                Description = request.Description
            };
            if (request.image != null)
            {
                if (!_fileService.IsPicture(request.image.FileName))
                {
                    response.AddError("The file must be an image");
                    return Ok(response);
                }
                if (_fileService.CheckPictureSizeInMB(request.image.Length, 2))
                {
                    response.AddError("The file must be less than 2 MB");
                    return Ok(response);
                }
                var imageName = _fileService.GenerateFileName(request.image.FileName);
                await _fileService.SavePic(request.image, imageName);
                drug.PicturePath = imageName;
            }
            _drugService.EditDrug(drug);

            return Ok(response); 
        }

        [HttpGet]
        [Route("GetRandomdrugs")]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetAllDrugsApiDTO.Response>>>> GetRandomdrugs()
        {
            var response = new ApiResponse<IEnumerable<GetAllDrugsApiDTO.Response>>();

            response.Data = await _drugService.GetRandomdrugs();

            return Ok(response); 
        }




    }
}
