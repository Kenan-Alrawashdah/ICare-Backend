using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.ApiDTO
{
    public class getAllEmployeeDTO
    {
        public int Id { get; set; }

        public string EmployeeName { get; set; }
        public string EmployeePhoneNumber { get; set; }

        public string EmployeeEmail { get; set; }

        public string RoleName { get; set; }
        public double PricePerHour { get; set; }
        public int DailyWorkingHours { get; set; }

    }
}
