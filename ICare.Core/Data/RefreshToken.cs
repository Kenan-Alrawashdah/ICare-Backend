using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.Data
{
    public class RefreshToken : BaseDataModel
    {
        public int UserId { get; set; }

        public string RToken { get; set; }
    }
}
