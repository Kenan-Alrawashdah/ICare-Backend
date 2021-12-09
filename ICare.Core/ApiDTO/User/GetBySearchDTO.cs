using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ICare.Core.ApiDTO
{
    public class GetBySearchDTO
    {
        public class Request
        {
            public string Search { get; set; }
        }

        public class Response
        {
            public int Id { get; set; }
            public string DrugName { get; set; }
            public double DrugPrice { get; set; }
            public string DrugPicturePath { get; set; }
        }
    }
}
