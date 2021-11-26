using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace ICare.Core.Data
{
    //Done
    public partial class Notification : BaseDataModel
    {
        [Required]
        [MaxLength(1500)]
        public string Message { get; set; }

        [Required]
        [ForeignKey(nameof(PatientId))]
        public int PatientId { get; set; }

        public virtual Patient Patient { get; set; }

       
    }
}