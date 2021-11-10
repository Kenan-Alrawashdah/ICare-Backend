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
    public class DrugDoseTimeController : Controller
    {
        private readonly ICRUDServices<DrugDoseTime> ICRUDServices;
        public DrugDoseTimeController(ICRUDServices<DrugDoseTime> ICRUDServices)
        {
            this.ICRUDServices = ICRUDServices;
        }
        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(typeof(DrugDoseTime), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool Create(DrugDoseTime t)
        {
            return ICRUDServices.Create(t);
        }
        [HttpDelete, Route("delete/{id}")]
        public bool Delete(int id)
        {
            return ICRUDServices.Delete(id);
        }
        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<DrugDoseTime> GetAll()
        {
            return ICRUDServices.GetAll();
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public DrugDoseTime GetById(int id)
        {
            return ICRUDServices.GetById(id);

        }
        [HttpPut]
        [Route("Update")]
        public bool Update(DrugDoseTime t)
        {
            return ICRUDServices.Update(t);

        }
    }
}
