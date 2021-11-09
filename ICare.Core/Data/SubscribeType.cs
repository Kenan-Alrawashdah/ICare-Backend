using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ICare.Core.Data
{
    //Done
    public class SubscribeType : BaseDataModel
    {
        public SubscribeType()
        {
            SubscribeList = new HashSet<Subscription>();
        }

        [Required]
        [MaxLength(150)]
        public string Type { get; set; }

        [Required]
        [Range(minimum: 0.01, maximum: 9999.99)]
        public double SubscribePrice { get; set; }

        [Required]
        [MaxLength(1000)]
        public string SubscribeDescription { get; set; }

        [Required]
        [Range(minimum: 1, maximum: 9999)]
        public int Days { get; set; }

        public virtual ICollection<Subscription> SubscribeList { get; set; }
    }
}