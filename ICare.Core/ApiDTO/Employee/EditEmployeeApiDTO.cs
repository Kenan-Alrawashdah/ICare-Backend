using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ICare.Core.ApiDTO
{
    public class EditEmployeeApiDTO
    {
        public class Request
        {
            public int Id { get; set; }
           

            /// <summary>
            /// 
            /// </summary>
            /// <example>0777777777</example>
            [Required]
            [MaxLength(15)]
            [Phone]
            public string PhoneNumber { get; set; }

            /// <example>First Name</example>
            [Required]
            [MaxLength(50)]
            public string FirstName { get; set; }

            /// <example>Last Name</example>
            [Required]
            [MaxLength(50)]
            public string LastName { get; set; }
            public double HourSalary { get; set; }
            public int MonthlyWorkingHours { get; set; }
            public double? PricePerHour { get; set; }
          
        }

        public class Response
        {
            public string Token { get; set; }
        }
    }
}
