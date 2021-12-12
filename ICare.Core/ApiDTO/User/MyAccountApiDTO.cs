using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.ApiDTO
    {
    
        public class MyAccountApiDTO
        {
            public class Request
            {
                public string FirstName { get; set; }

                public string LastName { get; set; }

                public string PhoneNumber { get; set; }

            }

            public class Response
            {
                public string FirstName { get; set; }

                public string LastName { get; set; }

                public string PhoneNumber { get; set; }

                public string Email { get; set; }
            }
        }
    
    }
