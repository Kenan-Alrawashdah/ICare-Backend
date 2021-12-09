using ICare.Core.ApiDTO;
using ICare.Core.ApiDTO.Admin.Role;
using ICare.Core.Data;
using ICare.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ICare.Core.IServices
{
   public  interface IEmployessServices : ICRUDRepository<Employee>
    {
        ApiResponse<RegistrationEmployeeApiDTO.Response> RegistrationEmployee(RegistrationEmployeeApiDTO.Request request);
        Task<bool> UpdateEmployee(EditEmployeeApiDTO.Request userModle);
        IEnumerable<GetRolesDTO.Response> GetAllRoles();
    }
}
