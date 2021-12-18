using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.ApiDTO
{
    public class GetPatientStatsLast5YearDTO
    {
        public int Year { get; set; }
        public int Count { get; set; }
    }
}
