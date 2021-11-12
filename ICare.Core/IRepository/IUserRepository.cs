using ICare.Core.ApiDTO;
using ICare.Core.Data;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace ICare.Core.IRepository
{
    public interface IUserRepository 
    {
        bool CheckEmailExist(string Email);
        bool Delete(int id);
        IEnumerable<ApplicationUser> GetAll();
        ApplicationUser GetById(int id);
        ApplicationUser GetUser(ClaimsPrincipal userClaims);
        bool Registration(RegistrationApiDTO.Request userModle);
        bool Update(ApplicationUser userModle);
    }
}
