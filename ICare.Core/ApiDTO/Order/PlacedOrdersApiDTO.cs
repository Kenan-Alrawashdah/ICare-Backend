using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.ApiDTO
{
    public class PlacedOrdersApiDTO
    {
        public class Response
        {
            public int OrderId { get; set; }

            public int Id { get; set; }
            public string AddressName { get; set; }

            public int UserId { get; set; }


            public string PhoneNumber { get; set; }


            public string City { get; set; }

            public int ZipCode { get; set; }

            public string Details { get; set; }

            public string Street { get; set; }

            public double lat { get; set; }

            public double lng { get; set; }
        }
    }
}
