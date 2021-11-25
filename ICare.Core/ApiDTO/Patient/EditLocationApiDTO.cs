using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ICare.Core.ApiDTO
{
    public class EditLocationApiDTO
    {
        public class Request
        {
            public int Id { get; set; }
            [MaxLength(50)]
            public string AddressName { get; set; }

            [MaxLength(50)]
            public string PhoneNumber { get; set; }


            [MaxLength(50)]
            public string City { get; set; }

            public int ZipCode { get; set; }

            [MaxLength(50)]
            public string Details { get; set; }

            [MaxLength(50)]
            public string Street { get; set; }
        }
    }
}
