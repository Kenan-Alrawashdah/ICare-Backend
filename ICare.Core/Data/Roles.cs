using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ICare.Core.Data
{
    public class Roles : BaseDataModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }


    }
}
