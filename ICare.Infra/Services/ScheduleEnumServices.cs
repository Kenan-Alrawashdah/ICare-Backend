using ICare.Core.Data;
using ICare.Core.IRepository;
using ICare.Core.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Infra.Services
{
    public class ScheduleEnumServices: IScheduleEnumServices
    {
        private readonly IScheduleEnumRepository _scheduleEnumRepository;
        public ScheduleEnumServices(IScheduleEnumRepository scheduleEnumRepository)
        {
            this._scheduleEnumRepository = scheduleEnumRepository;
        }
        public bool Create(ScheduleEnum t)
        {
            return _scheduleEnumRepository.Create(t);
        }
        public bool Delete(int id)
        {
            return _scheduleEnumRepository.Delete(id);
        }
        public IEnumerable<ScheduleEnum> GetAll()
        {
            return _scheduleEnumRepository.GetAll();
        }
        public ScheduleEnum GetById(int id)
        {
            return _scheduleEnumRepository.GetById(id);

        }
        public bool Update(ScheduleEnum t)
        {
            return _scheduleEnumRepository.Update(t);

        }
    }
}
