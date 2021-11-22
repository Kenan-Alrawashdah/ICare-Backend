using ICare.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.ApiDTO
{
    public class GetAllUserApiDTO
    {
        public class Response
        {
            public IEnumerable<ApplicationUser> Users { get; set; }
        }
    }
}
