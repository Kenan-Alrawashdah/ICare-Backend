using ICare.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.IRepository
{
   public interface IWorkRepository
    {
        void StartWork(Work work);
        void EndWork(int employeeId, DateTime endDate);
    }
}
