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
//    public class EmployeeController : ControllerBase
//    {

//            private readonly IEmployessServices _userServices;

//            public EmployeeController(IEmployessServices userServices)
//            {
//                this._userServices = userServices;
//            }

//            [HttpPost]
//            [Route("Create")]
//            [ProducesResponseType(type: typeof(bool), StatusCodes.Status200OK)]
//            [ProducesResponseType(StatusCodes.Status400BadRequest)]
//            public bool Create(Employee employeeModel)
//            {
//                return _userServices.Create(employeeModel);
//            }

//            [HttpPut]
//            [Route("Update")]
//            [ProducesResponseType(type: typeof(bool), StatusCodes.Status200OK)]
//            [ProducesResponseType(StatusCodes.Status400BadRequest)]
//            public bool Update(Employee employeeModel)
//            {
//                return _userServices.Update(employeeModel);
//            }

//            [HttpDelete]
//            [Route("Delete/{id}")]
//            [ProducesResponseType(type: typeof(bool), StatusCodes.Status200OK)]
//            [ProducesResponseType(StatusCodes.Status400BadRequest)]
//            public bool Delete(int id)
//            {
//                return _userServices.Delete(id);
//            }

//            [HttpGet]
//            [Route("GetById/{id}")]
//            [ProducesResponseType(type: typeof(Employee), StatusCodes.Status200OK)]
//            [ProducesResponseType(StatusCodes.Status400BadRequest)]
//            public Employee GetById(int id)
//            {
//                return _userServices.GetById(id);
//            }

//            [HttpGet]
//            [Route("GetAll")]
//            [ProducesResponseType(type: typeof(IEnumerable<Employee>), StatusCodes.Status200OK)]
//            [ProducesResponseType(StatusCodes.Status400BadRequest)]
//            public IEnumerable<Employee> GetAll()
//            {
//                return _userServices.GetAll();
//            }
//        }
//}
