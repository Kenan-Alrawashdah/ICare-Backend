using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.ApiDTO
{
    public class getAllOrdersForDeliveryDTO
    {
        public class Request
        {
            public int DeliveryId { get; set; }

        }

        public class Response
        {
            
            public int OrderId { get; set; }

            public int LocationId { get; set; }

            public int UserId { get; set; }
            public string CustomerName { get; set; }

            public double Amount { get; set; }
            public double lat { get; set; }
            public double lng { get; set; }

            public string Status { get; set; }


        }
    }
}
