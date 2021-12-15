using ICare.Core.ApiDTO;
using ICare.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.IServices
{
    public interface IAuthService
    {
        ResponseLoginDTO Authentication(LoginApiDTO.Request loginDTO);
    }
}
