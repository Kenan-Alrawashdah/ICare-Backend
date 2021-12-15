using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ICare.Core.ApiDTO
{
    public class CahngePasswordApiDTO
    {
        public class Request
        {
            [Required]
            public string OldPassword { get; set; }
            [RegularExpression(@"((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[\W]).{8,64})", ErrorMessage = "Please enter a valid password")]
            [Required]
            public string NewPassword { get; set; }
        }
    }
}
