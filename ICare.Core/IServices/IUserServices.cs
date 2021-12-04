using ICare.Core.ApiDTO;
using ICare.Core.Data;
using ICare.Core.IRepository;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ICare.Core.IServices
{
    public interface IUserServices 
    {
        bool AddOrUpdateProfilePicture(string imagePath, int userId);
        bool CheckEmailExist(string Email);
        bool Delete(int id);
        IEnumerable<ApplicationUser> GetAll();
        ApplicationUser GetById(int id);
        ApplicationUser GetUser(ClaimsPrincipal userClaims);
        Task<bool> Registration(RegistrationApiDTO.Request userModle);
        bool Update(int userId, MyAccountApiDTO.Request Modle);
        Task<bool> AddAdmin(ApplicationUser userModle);
        IEnumerable<GetBySearchDTO.Response> GetDrugByNameSearch(GetBySearchDTO.Request request);
        Task<bool> SetNewPassword(string email, string password);

        Task<LoginApiDTO.Response> LoginWithFacebookAsync(string accessToken);
    }
}
