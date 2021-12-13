using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.ApiDTO
{
    public class GetAllOpenOredersApiDTO
    {
        public class Response
        {
            public int Id { get; set; }
            public DateTime CreatedOn { get; set; }
            public double TotalPrice { get; set; }
            public string LastName { get; set; }
            public string FirstName { get; set; }
            public string Status { get; set; }
        }
    }
}
