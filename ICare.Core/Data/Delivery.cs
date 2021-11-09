using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICare.Core.Data
{
    public partial class Delivery : BaseDataModel
    {
        public Delivery()
        {
            Orders = new HashSet<Order>();
        }

        [Required]
        [ForeignKey(nameof(UserId))]
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }

        public  ICollection<Order> Orders { get; set; }
    }
}