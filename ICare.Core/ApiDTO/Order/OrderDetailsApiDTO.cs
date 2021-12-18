using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.ApiDTO
{
    public class OrderDetailsApiDTO
    {
        public class Response
        {
            public double TotalPrice { get; set; }
            public string Street { get; set; }
            public string Details { get; set; }
            public int ZipCode { get; set; }
            public string City { get; set; }
            public string PhoneNumber { get; set; }
            public string AddressName { get; set; }
            public string Status { get; set; }
            public IEnumerable<OrderDrugs> OrderDrugs { get; set; }

        }

        public class OrderDrugs
        {
            public string Name { get; set; }
            public double Price { get; set; }
            public string PicturePath { get; set; }
            public int Quantity { get; set; }
        }
    }
}
