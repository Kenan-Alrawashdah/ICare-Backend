using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ICare.Core.Data
{
    //Done
    public class StatusOrderEnum : BaseDataModel
    {
        public StatusOrderEnum()
        {
            Orders = new HashSet<Order>();
        }

        [Required]
        public string Status { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}