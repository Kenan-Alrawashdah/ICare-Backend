using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICare.Core.Data
{
    public class Patient : BaseDataModel
    {
        public Patient()
        {
            PatientDrugs = new HashSet<PatientDrugs>();
            Orders = new HashSet<Order>();
            HealthReports = new HashSet<HealthReport>();
            Notifications = new HashSet<Notification>();
            Cart = new HashSet<Cart>();
        }

        [Required]
        [ForeignKey(nameof(UserId))]
        public int UserId { get; set; }

        public ApplicationUser User { get; set; }

        [Range(minimum: 0.01, maximum: 10.0)]
        public double Liters { get; set; }

        public DateTime? SubscriptionValidation { get; set; }

        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection<PatientDrugs> PatientDrugs { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<HealthReport> HealthReports { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}