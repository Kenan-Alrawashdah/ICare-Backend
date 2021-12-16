using ICare.Core.ApiDTO.Patient;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.IServices
{
    public interface IProcessBackgroundService
    {
        void BringDrugsOnTime();
        void CheckWaterOnTime();
    }
}
