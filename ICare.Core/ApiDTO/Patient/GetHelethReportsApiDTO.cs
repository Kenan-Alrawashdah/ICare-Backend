using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.ApiDTO
{
    public class GetHelethReportsApiDTO
    {
        public class Request
        {
            public int Month { get; set; }

            public int Year { get; set; }
        }

        public class Reponse
        {
            public int Id { get; set; }

            public DateTime CreatedOn { get; set; }

            public string Type { get; set; }

            public string Value { get; set; }

        }
    }
}
