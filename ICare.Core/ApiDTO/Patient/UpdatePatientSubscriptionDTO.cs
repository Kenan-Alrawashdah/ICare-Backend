using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.ApiDTO
{
    public class UpdatePatientSubscriptionDTO
    {
        public class Request
        {
            public int PatientId { get; set; }

            public int SubscribeTypeId { get; set; }


        }
    }
}
