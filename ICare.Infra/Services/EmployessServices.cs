using ICare.Core.ApiDTO;
using ICare.Core.ApiDTO.Admin.Role;
using ICare.Core.Data;
using ICare.Core.IRepository;
using ICare.Core.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ICare.Infra.Services
{
   public class EmployessServices : IEmployessServices
    {
        private readonly IEmployessRepository _employeeRepository;
        private readonly IUserServices _userServices;
        private readonly IPasswordHashingService _passwordHashingService;
        public EmployessServices(IEmployessRepository employeeRepository,
                                 IUserServices userServices,
                                 IPasswordHashingService passwordHashingService
                                 )
        {
            this._employeeRepository = employeeRepository;
            _userServices = userServices;
            _passwordHashingService = passwordHashingService;
        }

        public ApiResponse<RegistrationEmployeeApiDTO.Response> RegistrationEmployee(RegistrationEmployeeApiDTO.Request request)
        {
            var response = new ApiResponse<RegistrationEmployeeApiDTO.Response>();
            if (_userServices.CheckEmailExist(request.Email))
            {
                response.AddError("The email is already exist");
                return response;
            }
            var hashedPassword = _passwordHashingService.GetHash(request.Password);
            var passwordForLogin = request.Password;
            request.Password = hashedPassword;
            _employeeRepository.RegistrationEmployee(request);

            return response;
        }
        public bool Create(Employee employeeModel)
        {
            return _employeeRepository.Create(employeeModel);
        }

        public bool Delete(int id)
        {
            return _userServices.Delete(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeRepository.GetAll();

        }

        public Employee GetById(int id)
        {
            return _employeeRepository.GetById(id);

        }

        public bool Update(Employee employeeModel)
        {
            return _employeeRepository.Update(employeeModel);
        }

        public async Task<bool> UpdateEmployee(EditEmployeeApiDTO.Request userModle)
        {   
           return await _employeeRepository.UpdateEmployee(userModle); 
        }

        public IEnumerable<GetRolesDTO.Response> GetAllRoles()
        {
            return _employeeRepository.GetAllRoles();
        }
    }
}
