using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.DTO
{
    public class ResponseLoginDTO
    {
        public string FirstName { get; set; }

        public string Email { get; set; }

        public List<string> RoleName { get; set; }

        public int Id { get; set; }
    }
}
