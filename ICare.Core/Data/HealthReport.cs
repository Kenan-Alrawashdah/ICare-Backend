using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICare.Core.Data
{
    //Done
    public partial class HealthReport : BaseDataModel
    {
        [Required]
        [ForeignKey(nameof(PatientId))]
        public int PatientId { get; set; }

        public Patient Patient { get; set; }

        [Required]
        public string Type { get; set; }

        //TODO: double or string
        [Required]
        public string Value { get; set; }
    }
}