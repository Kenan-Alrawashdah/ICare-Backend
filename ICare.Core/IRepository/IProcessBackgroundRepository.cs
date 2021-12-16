using ICare.Core.ApiDTO.Patient;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.IRepository
{
    public interface IProcessBackgroundRepository
    {
        IEnumerable<SendDrugByEmailDTO.Response> BringDrugsOnTime() ;
        IEnumerable<string> CheckWaterOnTime();
    }
}
