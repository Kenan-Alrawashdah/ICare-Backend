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
            
            
            public int PatientId { get; set; }
           
            public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
           
            [MaxLength(250)]
            public string CheckUpName { get; set; }
          
            [MaxLength(250)]
            public string BloodType { get; set; }
      

        }
    }
}
