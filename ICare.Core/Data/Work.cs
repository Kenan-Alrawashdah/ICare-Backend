using System;
using System.ComponentModel.DataAnnotations;

namespace ICare.Core.Data
{
    public class Work : BaseDataModel
    {
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }
    }
}