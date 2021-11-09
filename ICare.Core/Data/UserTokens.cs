using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ICare.Core.Data
{
    public class UserTokens : BaseDataModel
    {
        [Required]
        [ForeignKey(nameof(UserId))]
        public int UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string LoginProvider { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }
    }
}
