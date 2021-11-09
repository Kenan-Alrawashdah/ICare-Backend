using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ICare.Core.Data
{
    //Done
    public partial class NotificationTypes : BaseDataModel
    {
        public NotificationTypes()
        {
            Notifications = new HashSet<Notification>();
        }

        [Required]
        [MaxLength(150)]
        public string Type { get; set; }

        public virtual ICollection<Notification> Notifications { get; set; }
    }
}