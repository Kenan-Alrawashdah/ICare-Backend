using ICare.Core.Data;
using ICare.Core.IRepository;
using ICare.Core.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Infra.Services
{
    public class UserRolesServices : IUserRolesServices
    {
        private readonly IUserRolesRepository _userRolesRepository;

        public UserRolesServices(IUserRolesRepository userRepository)
        {
            this._userRolesRepository = userRepository;
        }
        public bool Create(UserRoles userRolesModle)
        {
            return _userRolesRepository.Create(userRolesModle);
        }

        public bool Delete(int id)
        {
            return _userRolesRepository.Delete(id);
        }

        public IEnumerable<UserRoles> GetAll()
        {
            return _userRolesRepository.GetAll();

        }

        public UserRoles GetById(int id)
        {
            return _userRolesRepository.GetById(id);

        }

        public bool Update(UserRoles userRolesModle)
        {
            return _userRolesRepository.Update(userRolesModle);

        }
    }
}
