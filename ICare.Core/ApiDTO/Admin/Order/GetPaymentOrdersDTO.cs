using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.ApiDTO
{
    public class GetPaymentOrdersDTO
    {
        public class Resqust
        {
            public DateTime From { get; set; }

            public DateTime To { get; set; }
        }

        public class Response
        {
            public string DrugName { get; set; }

            public double TotalPrice { get; set; }

            public DateTime OrderDate { get; set; }
            public int Quantity { get; set; }
        }


    }
}
