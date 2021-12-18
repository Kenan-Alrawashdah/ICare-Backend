using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.ApiDTO
{
    public class MyDrugsApiDto
    {
        public class Response
        {

           public IEnumerable<Drug> MyDrugs { get; set; }

        }

        public class Drug
        {
            public int Id { get; set; }

            public string DrugName { get; set; }

            public string ExpireDate { get; set; }

            public List<string> Times { get; set; } 
        }
    }
}
