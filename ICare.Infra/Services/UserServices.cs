using ICare.Core.ApiDTO;
using ICare.Core.Data;
using ICare.Core.IRepository;
using ICare.Core.IServices;
using System.Collections.Generic;
using System.Security.Claims;

namespace ICare.Infra.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        public bool Registration(RegistrationApiDTO.Request userModle)
        {
            return _userRepository.Registration(userModle);
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
        public ApplicationUser GetUser(ClaimsPrincipal userClaims)
        {
            return _userRepository.GetUser(userClaims);
        }
        public bool CheckEmailExist(string Email)
        {
            return _userRepository.CheckEmailExist(Email);

        }
    }
}
