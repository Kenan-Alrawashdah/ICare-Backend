using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICare.Core.Data
{
    //Done
    public partial class Order : BaseDataModel
    {
        public Order()
        {
            OrderDrugs = new HashSet<OrderDrugs>();
        }

        [Required]
        public double TotalPrice { get; set; }

        [Required]
        [ForeignKey(nameof(StatusId))]
        public int StatusId { get; set; }

        public StatusOrderEnum Status { get; set; }

        [ForeignKey(nameof(DeliveryId))]
        public int? DeliveryId { get; set; }

        public Delivery Delivery { get; set; }

        [Required]
        [ForeignKey(nameof(PatientId))]
        public int PatientId { get; set; }

        public Patient Patient { get; set; }

        [ForeignKey(nameof(LocationId))]
        public int LocationId { get; set; }

        public Location Location { get; set; }


        public ICollection<OrderDrugs> OrderDrugs { get; set; }
    }
}