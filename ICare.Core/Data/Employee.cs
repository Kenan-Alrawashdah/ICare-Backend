using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICare.Core.Data
{
    //TODO : 2143
    public partial class Employee : BaseDataModel
    {
        public double HourSalary { get; set; }
        public int MonthlyWorkingHours { get; set; }
        public double? PricePerHour { get; set; }

        [Required]
        [ForeignKey(nameof(UserId))]
        public int UserId { get; set; }

        public ApplicationUser User { get; set; }

        public List<Work> MyProperty { get; set; }
    }
}