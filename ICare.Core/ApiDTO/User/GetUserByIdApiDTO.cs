using ICare.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.ApiDTO
{
    public class GetUserByIdApiDTO
    {

        public class Response
        {
            
            public ApplicationUser User{ get; set; }
        }
    }
}
