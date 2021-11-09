using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace ICare.Core.ICommon
{
    public interface IDbContext
    {
        DbConnection Connection { get; }
    }
}
