using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ICare.Core.ApiDTO.Drug
{
    public class UpdateDrugApiDTO
    {
        public class Request
        {
            [Required]
            public int Id { get; set; }


            [Required]
            [MaxLength(150)]
            public string Name { get; set; }

            [Required]
            [Range(minimum: 0.01, maximum: 9999.99)]
            public double Price { get; set; }

            public IFormFile image { get; set; }

            [Required]
            [MaxLength(150)]
            public string Brand { get; set; }

            [Required]
            public int AvailableQuantity { get; set; }

            public string Description { get; set; }

        }
    }
}
