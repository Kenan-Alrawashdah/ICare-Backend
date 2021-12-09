using ICare.Core.ApiDTO;
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
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployessServices _employessServices;

        public EmployeeController(IEmployessServices employessServices)
        {
            this._employessServices = employessServices;
        }

        /// <summary>
        /// SignUp Page for Employee
        /// </summary>
        /// <param name="request"></param>
        /// <returns>token</returns>
        [HttpPost]
        [Route("EmployeeRegistration")]
        public ActionResult<ApiResponse<RegistrationEmployeeApiDTO.Response>> EmployeeRegistration(RegistrationEmployeeApiDTO.Request request)
        {
          return  _employessServices.RegistrationEmployee(request);
        }



        // [HttpPost]
        //[Route("Create")]
        //[ProducesResponseType(type: typeof(bool), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public bool Create(Employee employeeModel)
        //{
        //    return _employessServices.Create(employeeModel);
        //}

        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(type: typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse>> Update(EditEmployeeApiDTO.Request request)
        {  //TODO
            var response = new ApiResponse();
            if (ModelState.IsValid)
            {
                bool res = await _employessServices.UpdateEmployee(request);
                if (!res)
                    response.AddError("Erorr");
            }
            else
            {
                response.AddError("please complet info");
            }
          
            return Ok(response);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        [ProducesResponseType(type: typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ApiResponse> Delete(int id)
        {
            var respons = new ApiResponse();
           bool res = _employessServices.Delete(id);
            if(!res)
            {
                respons.AddError("this id Employee not found");
            }
            return Ok(respons);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        [ProducesResponseType(type: typeof(Employee), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Employee GetById(int id)
        {
            return _employessServices.GetById(id);
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(type: typeof(IEnumerable<Employee>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IEnumerable<Employee> GetAll()
        {
            return _employessServices.GetAll();
        }
    }
}
