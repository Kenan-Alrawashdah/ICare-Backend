using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ICare.Core.Data
{
    public class UserLogins : BaseDataModel
    {
        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }
        public string ProviderDisplayName { get; set; }
        [Required]
        [ForeignKey(nameof(UserId))]
        public int UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
