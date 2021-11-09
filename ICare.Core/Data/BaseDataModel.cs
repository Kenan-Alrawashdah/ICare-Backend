using System;
using System.ComponentModel.DataAnnotations;

namespace ICare.Core.Data
{
    public class BaseDataModel
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}