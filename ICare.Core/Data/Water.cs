using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.Data
{
    public class Water : BaseDataModel
    {

         public int PatientId { get; set; }

         public int Every { get; set; }

         public TimeSpan From { get; set; }

         public TimeSpan To { get; set; }
    }
}
