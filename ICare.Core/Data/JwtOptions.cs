using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.Data
{
    public class JwtOptions
    {
        public string Issuer { get; set; } = "a";

        public string Audience { get; set; } = "a";

        public string Key { get; set; } = "superSecretKey@345";

        public int Lifetime { get; set; } = 1;
    }
}
