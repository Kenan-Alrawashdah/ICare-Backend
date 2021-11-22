using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.ApiDTO
{
    public class GetCategoryByIdApiDTO
    {

        public class Response
        {
            public int id { get; set; }

            public string name { get; set; }

            public string imagePath { get; set; }
        }
    }
}
