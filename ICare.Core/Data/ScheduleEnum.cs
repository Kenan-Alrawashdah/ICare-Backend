using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ICare.Core.Data
{
    //Done
    public class ScheduleEnum : BaseDataModel
    {
        public ScheduleEnum()
        {
            PatientDrugs = new HashSet<PatientDrugs>();
        }

        [Required]
        [MaxLength(100)]
        public string ValueName { get; set; }

        public virtual ICollection<PatientDrugs> PatientDrugs { get; set; }
    }
}