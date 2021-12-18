using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ICare.Core.Data
{
    //Done
    public class SubscribeType : BaseDataModel
    {
        [Required]
        public double Price { get; set; }

        [Required]
        public int Days { get; set; }

        [Required]
        public bool OnSale { get; set; }

        public double PriceAfterSale { get; set; }

        [Required]
        public bool HasRibbon { get; set; }

        public string Ribbon { get; set; }

        [Required]
        public string Name { get; set; }

        public string RibbonColor { get; set; }
    }
}