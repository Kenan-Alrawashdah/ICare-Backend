using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ICare.Core.Data
{
    //Done
    public class Drug : BaseDataModel
    {
        public Drug()
        {
            Cart = new HashSet<Cart>();
            OrderDrugs = new HashSet<OrderDrugs>();
        }

        [Required]
        [ForeignKey(nameof(DrugCategoryId))]
        public int DrugCategoryId { get; set; }

        public DrugCategory DrugCategory { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        [Range(minimum: 0.01, maximum: 9999.99)]
        public double Price { get; set; }

        [MaxLength(250)]
        public string PicturePath { get; set; }

        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection<OrderDrugs> OrderDrugs { get; set; }
    }
}