using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ICare.Core.ApiDTO
{
    public class GetCartItemsApiDTO
    {
        public class Response
        {
            public int CartId { get; set; }
            public int DrugId { get; set; }

            public DateTime CreatedOn { get; set; }

            [Required]
            public string DrugCategory { get; set; }


            [Required]
            [MaxLength(150)]
            public string Name { get; set; }

            [Required]
            [Range(minimum: 0.01, maximum: 9999.99)]
            public double Price { get; set; }

            [Required]
            [MaxLength(250)]
            public string PicturePath { get; set; }

            [Required]
            [MaxLength(150)]
            public string Brand { get; set; }

            [Required]
            public int AvailableQuantity { get; set; }

            public string Description { get; set; }

            public int Quantity { get; set; }
        }
    }
}
