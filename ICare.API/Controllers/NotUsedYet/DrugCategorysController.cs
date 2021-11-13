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
//    public class DrugCategorysController : ControllerBase
//    {
//        private readonly IDrugCategoryService _drugCategoryService;

//        public DrugCategorysController(IDrugCategoryService drugCategoryService)
//        {
//            _drugCategoryService = drugCategoryService;
//        }

//        [HttpGet("GetAll")]
//        [ProducesResponseType(typeof(List<DrugCategory>), StatusCodes.Status200OK)]
//        public List<DrugCategory> GetAllDrugCategory()
//        {
//            return _drugCategoryService.GetAll().ToList();
//        }

//        [HttpPost("Add")]
//        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
//        public bool AddDrugCategory(DrugCategory drugCategory)
//        {
//            return _drugCategoryService.Create(drugCategory);
//        }

//        [HttpDelete("Delete/{drugCategoryId:int}")]
//        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
//        public bool DeleteDrugCategory(int drugCategoryId)
//        {
//            return _drugCategoryService.Delete(drugCategoryId);
//        }

//        [HttpPut("Update")]
//        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
//        public bool UpdateDrugCategory(DrugCategory drugCategory)
//        {
//            return _drugCategoryService.Update(drugCategory);
//        }

//        [HttpPost("GetById/{drugCategoryId:int}")]
//        [ProducesResponseType(typeof(DrugCategory), StatusCodes.Status200OK)]
//        public DrugCategory GetDrugCategoryById(int drugCategoryId)
//        {
//            return _drugCategoryService.GetById(drugCategoryId);
//        }
//    }
//}
