using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.ApiDTO
{
    public class GetNotifications
    {
        public class Request
        {
            public DateTime Date { get; set; }
        }

        public class Response
        {
        public DateTime CreatedOn { get; set; }

        public string Message { get; set; }
        }

    }
}
