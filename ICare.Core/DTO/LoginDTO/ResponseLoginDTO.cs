using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.DTO
{
    public class ResponseLoginDTO
    {
        public string UserName { get; set; }

        public List<string> RoleName { get; set; }

        public int Id { get; set; }
    }
}
