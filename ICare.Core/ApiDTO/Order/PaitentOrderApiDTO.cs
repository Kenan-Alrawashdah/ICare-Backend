using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.ApiDTO
{
    public class PaitentOrderApiDTO
    {
        public class Response
        {

            public int Id { get; set; }

            public DateTime CreatedOn { get; set; }
            
            public double TotalPrice { get; set; }

            public string Status { get; set; }


        }
    }
}
