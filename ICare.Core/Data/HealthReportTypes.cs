using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ICare.Core.Data
{
    //Done
    public partial class HealthReportTypes : BaseDataModel
    {
        public HealthReportTypes()
        {
            HealthReports = new HashSet<HealthReport>();
        }

        [Required]
        [MaxLength(150)]
        public string Type { get; set; }

        public virtual ICollection<HealthReport> HealthReports { get; set; }
    }
}