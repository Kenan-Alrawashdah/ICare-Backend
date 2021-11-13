//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using ICare.Core.Data;
//using ICare.Core.IServices;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace ICare.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class DrugsController : ControllerBase
//    {
//        private readonly IDrugService _drugService;

//        public DrugsController(IDrugService drugService)
//        {
//            _drugService = drugService;
//        }

//        [HttpGet("GetAll")]
//        [ProducesResponseType(typeof(List<Drug>), StatusCodes.Status200OK)]
//        public List<Drug> GetAllDrugs()
//        {
//            return _drugService.GetAll().ToList();
//        }

//        [HttpPost("Add")]
//        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
//        public bool AddDrug(Drug drug)
//        {
//            return _drugService.Create(drug);
//        }

//        [HttpDelete("Delete/{drugId:int}")]
//        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
//        public bool DeleteDrug(int drugId)
//        {
//            return _drugService.Delete(drugId);
//        }

//        [HttpPut("Update")]
//        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
//        public bool UpdateDrug(Drug drug)
//        {
//            return _drugService.Update(drug);
//        }

//        [HttpPost("GetById/{drugId:int}")]
//        [ProducesResponseType(typeof(Drug), StatusCodes.Status200OK)]
//        public Drug GetDrugById(int drugId)
//        {
//            return _drugService.GetById(drugId);
//        }
//    }
//}
