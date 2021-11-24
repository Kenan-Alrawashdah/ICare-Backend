using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICare.Core.ApiDTO;
using ICare.Core.Data;
using ICare.Core.IServices;
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

        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(List<Drug>), StatusCodes.Status200OK)]
        public List<Drug> GetAllDrugs()
        {
            return _drugService.GetAll().ToList();
        }

        
        [HttpPost]
        [Route("AddDrug")]
        public ActionResult<ApiResponse> AddDrug([FromForm]AddDrugApiDto.Request request)
        {
            //TODO: image resize 
            var response = new ApiResponse();
            if (!_fileService.IsPicture(request.Picture.FileName))
            {
                response.AddError("The File must be image");
                return Ok(response);
            }
            if (_fileService.CheckPictureSizeInMB(request.Picture.Length, 1))
            {
                response.AddError("The image must be less than 1 MB");
                return Ok(response);
            }
            var imageName = _fileService.GenerateFileName(request.Picture.FileName);
            _fileService.SavePic(request.Picture, imageName);
            var drug = new Drug
            {
                Name = request.Name,
                Price = request.Price,
                DrugCategoryId = request.DrugCategoryId,
                PicturePath = imageName
            };
            _drugService.Create(drug);

            return Ok(response);
        }

        [HttpDelete("Delete/{drugId:int}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public bool DeleteDrug(int drugId)
        {
            return _drugService.Delete(drugId);
        }

        [HttpPut("Update")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public bool UpdateDrug(Drug drug)
        {
            return _drugService.Update(drug);
        }

        [HttpPost("GetById/{drugId:int}")]
        [ProducesResponseType(typeof(Drug), StatusCodes.Status200OK)]
        public Drug GetDrugById(int drugId)
        {
            return _drugService.GetById(drugId);
        }
    }
}
