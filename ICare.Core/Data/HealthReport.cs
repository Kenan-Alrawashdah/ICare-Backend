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
        [ForeignKey(nameof(TypeId))]
        public int TypeId { get; set; }

        public HealthReportTypes Type { get; set; }

        //TODO: double or string
        [Required]
        public double Value { get; set; }
    }
}