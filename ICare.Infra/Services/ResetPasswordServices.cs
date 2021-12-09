using ICare.Core.ApiDTO;
using ICare.Core.IServices;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace ICare.Infra.Services
{
    public  class ResetPasswordServices : IResetPasswordServices
    {
        private readonly IUserServices _userServices;
        private readonly IPasswordHashingService _passwordHashingService;
        private readonly IEmailServices _emailServices;

        public ResetPasswordServices(IUserServices userServices,IPasswordHashingService passwordHashingService,IEmailServices emailServices)
        {
            this._userServices = userServices;
            this._passwordHashingService = passwordHashingService;
            this._emailServices = emailServices;
        }
        public bool ForgotPassword(ChangeUserPasswordDTO.Request request)
        {

            if (_userServices.CheckEmailExist(request.Email))
            {
                var password = CreateRandomPassword(9);
                var body = "We are excited to tell you that your password changed successfully.\n" + "Your New Password : " + password;
                _emailServices.SendEmail(request.Email, "Password changed successfully", body);
               var pass =  _passwordHashingService.GetHash(password);
                _userServices.SetNewPassword(request.Email , pass);
                return true; 
            }
            else
            {
                return false;
            }

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
