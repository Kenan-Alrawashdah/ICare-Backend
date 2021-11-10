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
        private readonly IScheduleEnumServices _scheduleEnumServices;
        public ScheduleEnumServices(IScheduleEnumServices scheduleEnumServices)
        {
            this._scheduleEnumServices = scheduleEnumServices;
        }
        public bool Create(ScheduleEnum t)
        {
            return _scheduleEnumServices.Create(t);
        }
        public bool Delete(int id)
        {
            return _scheduleEnumServices.Delete(id);
        }
        public IEnumerable<ScheduleEnum> GetAll()
        {
            return _scheduleEnumServices.GetAll();
        }
        public ScheduleEnum GetById(int id)
        {
            return _scheduleEnumServices.GetById(id);

        }
        public bool Update(ScheduleEnum t)
        {
            return _scheduleEnumServices.Update(t);

        }
    }
}
