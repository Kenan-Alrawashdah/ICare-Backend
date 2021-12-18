using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ICare.Core.ApiDTO
{
    public class RegistrationEmployeeApiDTO
    {
        public class Request
        {
           // public int Id { get; set; }
            /// <summary>
            /// the Email Of the Employee
            /// </summary>
            /// <example>Test@test.test</example>
            [Required]
            [MaxLength(150)]
            [EmailAddress]
            public string Email { get; set; }

            /// <summary>
            /// the password of the Employee
            /// </summary>
            /// <example>Q!qwe123</example>
            [Required]
            [MaxLength(100)]
            [RegularExpression(@"((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[\W]).{8,64})", ErrorMessage = "Please enter a valid password")]
            public string Password { get; set; }

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
            //public double? PricePerHour { get; set; }
            public int RoleId { get; set; }
        }

        public class Response
        {
            public string Token { get; set; }
        }
    }
}
