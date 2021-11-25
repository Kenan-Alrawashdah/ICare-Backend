using ICare.Core.ApiDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.IServices
{
    public interface IResetPasswordServices
    {
        bool ForgotPassword(ChangeUserPasswordDTO.Request request);
    }
}
