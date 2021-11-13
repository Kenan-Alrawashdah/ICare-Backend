using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ICare.Core.ApiDTO
{
    public class AddpatientDrugApiDTO
    {
        public class Request
        {
            [Required]
            [MaxLength(250)]
            public string DrugName { get; set; }


            /// <summary>
            /// The started date of taking the drug
            /// "if needed to be not in the same time of adding the drug"
            /// </summary>
            [Required]
            public DateTime StartDate { get; set; } = DateTime.UtcNow;

            //If needed
            public DateTime? EndDate { get; set; }


            /// <summary>
            /// first
            /// </summary>
            /// <example>"08:30:00" </example>
            public string drugDoseTime1 { get; set; }
            /// <summary>
            /// second
            /// </summary>
            /// <example>"12:30:00" </example>
            public string drugDoseTime2 { get; set; }
            /// <summary>
            /// third 
            /// </summary>
            /// <example>"06:30:00" </example>
            public string drugDoseTime3 { get; set; }
            /// <summary>
            /// fourth 
            /// </summary>
            /// <example>"023:30:00" </example>
            public string drugDoseTime4 { get; set; }

        }


        public class Response
        {

        }
    }
}
