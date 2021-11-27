using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace ICare.Core.Data
{
    public partial class Subscription : BaseDataModel
    {
        [Required]
        [ForeignKey(nameof(PatientId))]
        public int PatientId { get; set; }

        public virtual Patient Patient { get; set; }

        [Required]
        public DateTime Expirationdate { get; set; }

        [Required]
        [ForeignKey(nameof(SubscribeTypeId))]
        public int SubscribeTypeId { get; set; }

        public virtual SubscribeType Type { get; set; }
    }
}