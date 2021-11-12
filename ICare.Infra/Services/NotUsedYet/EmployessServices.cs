using ICare.Core.Data;
using ICare.Core.IRepository;
using ICare.Core.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Infra.Services
{
   public class EmployessServices : IEmployessServices
    {
        private readonly IEmployessRepository _userRepository;

        public EmployessServices(IEmployessRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        public bool Create(Employee employeeModel)
        {
            return _userRepository.Create(employeeModel);
        }

        public bool Delete(int id)
        {
            return _userRepository.Delete(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _userRepository.GetAll();

        }

        public Employee GetById(int id)
        {
            return _userRepository.GetById(id);

        }

        public bool Update(Employee employeeModel)
        {
            return _userRepository.Update(employeeModel);

        }
    }
}
