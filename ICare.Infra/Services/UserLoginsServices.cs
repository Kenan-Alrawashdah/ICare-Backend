using ICare.Core.Data;
using ICare.Core.IRepository;
using ICare.Core.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Infra.Services
{
    public class UserLoginsServices : IUserLoginsServices
    {
        private readonly IUserLoginsRepository _userRepository;

        public UserLoginsServices(IUserLoginsRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        public bool Create(UserLogins userLoginsModel)
        {
            return _userRepository.Create(userLoginsModel);
        }

        public bool Delete(int id)
        {
            return _userRepository.Delete(id);
        }

        public IEnumerable<UserLogins> GetAll()
        {
            return _userRepository.GetAll();

        }

        public UserLogins GetById(int id)
        {
            return _userRepository.GetById(id);

        }

        public bool Update(UserLogins userLoginsModel)
        {
            return _userRepository.Update(userLoginsModel);

        }
    }
}
