using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICare.Core.Data
{
    //Done
    public partial class PatientDrugs : BaseDataModel
    {
        public PatientDrugs()
        {
            DrugDoseTimes = new HashSet<DrugDoseTime>();
        }

        [Required]
        [ForeignKey(nameof(PatientId))]
        public int PatientId { get; set; }

        public Patient Patient { get; set; }

        /// <summary>
        /// Use ScheduleEnum  class
        /// </summary>
        [Required]
        [ForeignKey(nameof(ScheduleId))]
        public int ScheduleId { get; set; }

        public ScheduleEnum Schedule { get; set; }

        /// <summary>
        /// The started date of taking the drug
        /// "if needed to be not in the same time of adding the drug"
        /// </summary>
        [Required]
        public DateTime StartDate { get; set; } = DateTime.UtcNow;

        //If needed
        public DateTime? EndDate { get; set; }

        public virtual ICollection<DrugDoseTime> DrugDoseTimes { get; set; }
    }
}