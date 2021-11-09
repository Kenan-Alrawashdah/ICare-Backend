using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICare.Core.Data
{
    //TODO: implement the identity here 
    public class ApplicationUser 
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(250)]
        public string ProfilePicturePath { get; set; }

        [ForeignKey(nameof(LocationId))]
        public int? LocationId { get; set; }

        public Location Location { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public int? EmployeeId { get; set; }

        public Employee Employee { get; set; }

        [ForeignKey(nameof(PatientId))]
        public int? PatientId { get; set; }

        public Patient Patient { get; set; }
    }
}