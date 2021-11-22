using ICare.Core.ApiDTO;
using ICare.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.IRepository
{
    public interface IJWTRepository
    {
        ResponseLoginDTO Authentication(LoginApiDTO.Request login);

    }
}
