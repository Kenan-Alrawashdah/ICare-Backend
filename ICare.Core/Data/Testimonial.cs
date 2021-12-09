using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ICare.Core.Data
{
    public class Testimonial:BaseDataModel
    {
        [Required]
        [MaxLength(1500)]
        public string userName { get; set; }
        [Required]
        [MaxLength(1500)]
        public string userSubject { get; set; }
        [Required]
        [MaxLength(1500)]
        public string userEmail { get; set; }
        [MaxLength(1500)]
        public string userPhone { get; set; }
        [Required]
        [MaxLength(1500)]
        public string userMessage { get; set; }
        public bool isProved { get; set; } = false;
    }
}
