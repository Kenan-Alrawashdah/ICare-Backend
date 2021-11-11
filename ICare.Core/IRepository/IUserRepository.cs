using ICare.Core.Data;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace ICare.Core.IRepository
{
    public interface IUserRepository : ICRUDRepository<ApplicationUser>
    {
        bool CheckEmailExist(string Email);
        ApplicationUser GetUser(ClaimsPrincipal userClaims);
    }
}
