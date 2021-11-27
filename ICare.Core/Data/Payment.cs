using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ICare.Core.Data
{
    public class Payment : BaseDataModel
    {
        [Required]
        [MaxLength(50)]
        public int CardNumber { get; set; }
        [Required]
        [MaxLength(50)]
        public string Expirydate { get; set; }
        [Required]
        [MaxLength(50)]
        public int cvcCode { get; set; }
        [Required]
        [MaxLength(50)]
        public string CardName { get; set; }
        [Required]
        [MaxLength(50)]
        public double Balance { get; set; }
        
    }
}
