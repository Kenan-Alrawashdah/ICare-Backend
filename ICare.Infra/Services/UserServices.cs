using ICare.Core.ApiDTO;
using ICare.Core.Data;
using ICare.Core.IRepository;
using ICare.Core.IServices;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ICare.Infra.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IFacebookAuthService _facebookAuthService;
        private readonly IJWTService _jWTService;
        private readonly IPasswordHashingService _passwordHashingService;
        

        public UserServices(IUserRepository userRepository, IFacebookAuthService facebookAuthService, IJWTService jWTService, IPasswordHashingService passwordHashingService)
        {
            this._userRepository = userRepository;
            this._facebookAuthService = facebookAuthService;
            this._jWTService = jWTService;
            this._passwordHashingService = passwordHashingService;
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

        public bool Update(int userId, MyAccountApiDTO.Request Modle)
        {
            return _userRepository.Update( userId,  Modle);
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

       public async Task<bool> SetNewPassword(string email, string password)
        {
            return await _userRepository.SetNewPassword(email, password);
        }



        public async Task<LoginApiDTO.Response> LoginWithFacebookAsync(string accessToken)
        {
            await _facebookAuthService.ValidateAccressTokenAsync(accessToken);

            var userInfo = await _facebookAuthService.GetUserInfoAsync(accessToken);
            var user = _userRepository.CheckEmailExist(userInfo.Id + "@facebook.com");
            var password = CreateRandomPassword(9);

            if (user == false)
            {
                var hashedPassword = _passwordHashingService.GetHash(password);

                RegistrationApiDTO.Request request = new RegistrationApiDTO.Request()
                {
                    Email = userInfo.Id + "@facebook.com",
                    FirstName = userInfo.FirstName,
                    LastName = userInfo.LastName,
                    PhoneNumber = "",
                    Password = hashedPassword
                };

                _userRepository.Registration(request);

            }

            var result = new LoginApiDTO.Response();
            result.Token = _jWTService.Auth(userInfo.Id + "@facebook.com", password);
            return result;
        }
        public string CreateRandomPassword(int PasswordLength)
        {
            string _allowedChars = "0123456789abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ";
            Random randNum = new Random();
            char[] chars = new char[PasswordLength];
            int allowedCharCount = _allowedChars.Length;
            for (int i = 0; i < PasswordLength; i++)
            {
                chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
            }
            return new string(chars);
        }
    }
}
