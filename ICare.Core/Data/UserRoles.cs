using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ICare.Core.Data
{
    public class UserRoles : BaseDataModel
    {
        [Required]
        [ForeignKey(nameof(UserId))]
        public int UserId { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        [ForeignKey(nameof(RoleId))]
        public int RoleId { get; set; }

        public Roles Role { get; set; }
    }
}
