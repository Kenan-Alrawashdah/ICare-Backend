using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ICare.Core.Data
{
    //Done
    public class DrugCategory : BaseDataModel
    {
        public DrugCategory()
        {
            Drugs = new HashSet<Drug>();
        }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string PicturePath { get; set; }

        public ICollection<Drug> Drugs { get; set; }
    }
}