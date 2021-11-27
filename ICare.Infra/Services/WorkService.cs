using ICare.Core.Data;
using ICare.Core.IRepository;
using ICare.Core.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Infra.Services
{
    public class WorkService : IWorkService
    {
        private readonly IWorkRepository _workRepository;

        public WorkService(IWorkRepository workRepository)
        {
            _workRepository = workRepository;
        }

        public void EndWork(int employeeId, DateTime endDate)
        {
             _workRepository.EndWork(employeeId, endDate);
        }

        public void StartWork(Work work)
        {
             _workRepository.StartWork(work);
        }
    }
}
