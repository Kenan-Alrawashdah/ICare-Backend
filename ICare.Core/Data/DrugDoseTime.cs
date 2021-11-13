using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICare.Core.Data
{
    //Done
    public class DrugDoseTime : BaseDataModel
    {
        [ForeignKey(nameof(PatientDrugId))]
        public int PatientDrugId { get; set; }

        public PatientDrugs PatientDrug { get; set; }

        [Required]
        public string Time { get; set; }
    }
}