using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.ApiDTO
{
    public class AddQuantityApiDTO
    {
        public class Request
        {
            public int DrugId { get; set; }
            public int Quantity { get; set; }
        }
    }
}
