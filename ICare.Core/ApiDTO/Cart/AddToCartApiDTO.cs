using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.ApiDTO
{
    public class AddToCartApiDTO
    {
        public class Request
        {
            public int drugId { get; set; }
            public int Quantity { get; set; }

        }
    }
}
