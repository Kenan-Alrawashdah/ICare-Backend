using ICare.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.IServices
{
    public interface IJWTService
    {
        string Auth(RequestLoginDTO loginDTO);
    }
}
