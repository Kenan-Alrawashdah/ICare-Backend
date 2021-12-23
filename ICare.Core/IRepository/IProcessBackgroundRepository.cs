using ICare.Core.ApiDTO.Patient;
using ICare.Core.ApiDTO.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.IRepository
{
    public interface IProcessBackgroundRepository
    {
        IEnumerable<SendDrugByEmailDTO.Response> BringDrugsOnTime() ;
        IEnumerable<string> CheckWaterOnTime();
        IEnumerable<SendDrugByEmailDTO.Response> CheckExpierDrug();
        IEnumerable<GetExpierSubscriptionDTO> CheckExpierSubscription();
    }
}
