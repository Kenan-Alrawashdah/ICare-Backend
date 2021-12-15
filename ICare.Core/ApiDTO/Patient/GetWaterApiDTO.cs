using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.ApiDTO
{
   public class GetWaterApiDTO
    {
        public class Response
        {
            public int Id { get; set; }

            public int Every { get; set; }

            public string From { get; set; }

            public string To { get; set; }
        }
    }
}
