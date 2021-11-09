using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICare.Core.Data
{
    //Done
    public partial class Cart : BaseDataModel
    {
        [Required]
        [ForeignKey(nameof(PatientId))]
        public int PatientId { get; set; }

        public Patient Patient { get; set; }

        [Required]
        [ForeignKey(nameof(DrugId))]
        public int DrugId { get; set; }

        public Drug Drugs { get; set; }
    }
}