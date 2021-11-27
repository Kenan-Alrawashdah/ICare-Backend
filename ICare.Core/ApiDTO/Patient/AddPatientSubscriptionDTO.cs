using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.ApiDTO
{
    public class AddPatientSubscriptionDTO
    {
        public class Request
        {
            public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

            public int PatientId { get; set; }

            public int SubscribeTypeId { get; set; }


        }

    }
}
