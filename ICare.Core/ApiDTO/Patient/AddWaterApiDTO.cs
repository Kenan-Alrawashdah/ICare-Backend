using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.ApiDTO
{
    public class AddWaterApiDTO
    {
        public class Request
        {

            public int Every { get; set; }

            public string From { get; set; }

            public string To { get; set; }
        }
    }
}
