using ICare.Core.ApiDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.IServices
{
    public interface IResetPasswordServices
    {
        string CreateRandomPassword(int PasswordLength);
        bool ForgotPassword(ChangeUserPasswordDTO.Request request);
    }
}
