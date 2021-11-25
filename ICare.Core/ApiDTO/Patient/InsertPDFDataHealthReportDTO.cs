using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ICare.Core.ApiDTO
{
    public class InsertPDFDataHealthReportDTO
    {
        public class Request
        {
            [Required]
            [MaxLength(250)]
            public int PatientId { get; set; }
            [Required]
            public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
            [Required]
            [MaxLength(250)]
            public string CheckUpName { get; set; }
            [Required]
            [MaxLength(250)]
            public string BloodType { get; set; }
            [Required]
            [MaxLength(250)]
            public string BloodSugarLevel { get; set; }

            [Required]
            public string CheckUpDate { get; set; }

        }
    }
}
