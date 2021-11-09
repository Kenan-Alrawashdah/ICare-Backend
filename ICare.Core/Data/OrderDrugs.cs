using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICare.Core.Data
{
    //Done
    public partial class OrderDrugs : BaseDataModel
    {
        [Required]
        [Range(minimum: 1, maximum: 9999)]
        public int Quantity { get; set; }

        [Required]
        [ForeignKey(nameof(DrugsId))]
        public int DrugsId { get; set; }

        public virtual Drug Drugs { get; set; }

        [Required]
        [ForeignKey(nameof(OrderId))]
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }
    }
}