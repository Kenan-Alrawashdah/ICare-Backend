using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.Data
{
    public class JwtOptions
    {

        public string Key { get; set; } = "superSecretKey@345";

        public int Lifetime { get; set; } = 10;
    }
}
