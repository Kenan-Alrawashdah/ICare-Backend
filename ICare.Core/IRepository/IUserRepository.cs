﻿using ICare.Core.ApiDTO;
using ICare.Core.Data;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ICare.Core.IRepository
{
    public interface IUserRepository 
    {
        Task<bool> AddAdmin(ApplicationUser userModle);
        bool AddOrUpdateProfilePicture(string imagePath, int userId);
        bool CheckEmailExist(string Email);
        bool Delete(int id);
        IEnumerable<ApplicationUser> GetAll();
        ApplicationUser GetById(int id);
        ApplicationUser GetUser(ClaimsPrincipal userClaims);
        Task<bool> Registration(RegistrationApiDTO.Request userModle);
        bool Update(ApplicationUser userModle);

        IEnumerable<GetBySearchDTO.Response> GetDrugByNameSearch(GetBySearchDTO.Request request);
        Task<bool> SetNewPassword(string email, string password);
    }
}
