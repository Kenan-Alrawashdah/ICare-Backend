using ICare.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.IServices
{
   public interface IWorkService
    {
        void StartWork(Work work);
        void EndWork(int employeeId, DateTime endDate);
    }
}
