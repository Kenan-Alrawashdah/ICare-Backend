using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ICare.Core.ApiDTO
{
    public class AddDrugToShopApiDTO
    {
        public class Resqust
        {
            /// <summary>
            /// The id of the category 
            /// </summary>
            /// <example>1</example>
            [Required]
            public int DrugCategoryId { get; set; }

            /// <summary>
            /// The name of the drug
            /// </summary>
            /// <example>test drug name</example>
            [Required]
            [MaxLength(150)]
            public string Name { get; set; }

            /// <summary>
            /// The price of the drug
            /// </summary>
            /// <example>100.9</example>
            [Required]
            [Range(minimum: 0.01, maximum: 9999.99)]
            public double Price { get; set; }

            /// <summary>
            /// The picture of the drug
            /// </summary>
            [MaxLength(250)]
            public string PicturePath { get; set; }
        }
        public class Response
        {
            public int i { get; set; }
        }
    }
}
