using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.ApiDTO.Patient
{
    public class SendDrugByEmailDTO
    {
        public class Response
        {
            public int Id { get; set; }
            public string Email { get; set; }
            public string NameDrug { get; set; }
        }
    }
}
