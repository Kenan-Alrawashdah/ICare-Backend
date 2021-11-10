using ICare.Core.Data;
using ICare.Core.IRepository;
using ICare.Core.IServices;
using System.Collections.Generic;

namespace ICare.Infra.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        public bool Create(ApplicationUser userModle)
        {
            return _userRepository.Create(userModle);
        }

        public bool Delete(int id)
        {
            return _userRepository.Delete(id);
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return _userRepository.GetAll();

        }

        public ApplicationUser GetById(int id)
        {
            return _userRepository.GetById(id);

        }

        public bool Update(ApplicationUser userModle)
        {
            return _userRepository.Update(userModle);

        }
    }
}
