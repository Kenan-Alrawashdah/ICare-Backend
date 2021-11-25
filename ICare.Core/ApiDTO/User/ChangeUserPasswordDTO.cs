using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ICare.Core.ApiDTO
{
    public class ChangeUserPasswordDTO
    {
        public class Request
        {
            [Required]
            [MaxLength(250)]
            [EmailAddress]
            public string Email { get; set; }





        }
    }
}
