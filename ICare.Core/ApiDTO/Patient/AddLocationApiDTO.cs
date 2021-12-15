using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.ApiDTO
{
    public class AddLocationApiDTO
    {
        public class Request
        {
            public string AddressName { get; set; }

            public string  PhoneNumber { get; set; }

            public string City { get; set; }

            public string Street { get; set; }

            public string Details { get; set; }

            public int ZipCode { get; set; }

            public double Lat { get; set; }

            public double Lng { get; set; }
        }

        
    }
}
