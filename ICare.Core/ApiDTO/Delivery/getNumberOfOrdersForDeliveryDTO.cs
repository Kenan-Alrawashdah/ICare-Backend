using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.ApiDTO
{
    public class getNumberOfOrdersForDeliveryDTO
    {
        public class Request
        {
            public int DeliveryId { get; set; }

        }

        public class Response
        {
            public string NumberOfOrders { get; set; }

        }
    }
}
