using ICare.Core.ApiDTO;
using ICare.Core.Data;
using ICare.Core.IRepository;
using ICare.Core.IServices;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ICare.Infra.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        public async Task<bool> Registration(RegistrationApiDTO.Request userModle)
        {
            return await _userRepository.Registration(userModle);
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

        public bool AddOrUpdateProfilePicture(string imagePath, int userId)
        {
            return _userRepository.AddOrUpdateProfilePicture(imagePath, userId);
        }

        public async Task<bool> AddAdmin(ApplicationUser userModle)
        {
            return await _userRepository.AddAdmin(userModle);

        }

        public IEnumerable<GetBySearchDTO.Response> GetDrugByNameSearch(GetBySearchDTO.Request request)
        {
            return  _userRepository.GetDrugByNameSearch(request);
        }

        public Task<bool> ForgotPassword(ChangeUserPasswordDTO.Request request)
        {
            return _userRepository.ForgotPassword(request);
        }
    }
}
