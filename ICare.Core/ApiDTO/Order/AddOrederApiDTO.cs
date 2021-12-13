using System.Collections.Generic;

namespace ICare.Core.ApiDTO
{
    public class AddOrederApiDTO
    {
        public class Request
        {
            public double TotalPrice { get; set; }
            public int LocationId { get; set; }

            public List<int> cartsId { get; set; }

        }


    }
}
