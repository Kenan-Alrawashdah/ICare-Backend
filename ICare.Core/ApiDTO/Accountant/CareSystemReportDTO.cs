using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.ApiDTO
{
    public class CareSystemReportDTO
    {
        public string Name { get; set; }
        public double OrderAmount { get; set; }
        public double Profits { get; set; }

        public DateTime OrderDate { get; set; }


    }
}
