using ICare.Core.ApiDTO;
using ICare.Core.Data;
using ICare.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

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
        bool Registration(RegistrationApiDTO.Request userModle);
        bool Update(ApplicationUser userModle);
    }
}
