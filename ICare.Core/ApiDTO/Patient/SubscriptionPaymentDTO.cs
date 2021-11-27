using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ICare.Core.ApiDTO
{
    public class SubscriptionPaymentDTO
    {
        public class Request
        {
            [Required]
            [MaxLength(250)]
            public int CardNumber { get; set; }

            [Required]
            [MaxLength(250)]
            public string Expirydate { get; set; }
            [Required]
            [MaxLength(250)]
            public int cvcCode { get; set; }
            [Required]
            [MaxLength(250)]
            public string CardName { get; set; }





        }
    }
}
