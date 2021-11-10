using ICare.Core.Data;
using ICare.Core.IRepository;
using ICare.Core.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Infra.Services
{
    public class ScheduleEnumServices: ICRUDServices<ScheduleEnum>
    {
        private readonly ICRUDRepository<ScheduleEnum> ICRUDRepository;
        public ScheduleEnumServices(ICRUDRepository<ScheduleEnum> ICRUDRepository)
        {
            this.ICRUDRepository = ICRUDRepository;
        }
        public bool Create(ScheduleEnum t)
        {
            return ICRUDRepository.Create(t);
        }
        public bool Delete(int id)
        {
            return ICRUDRepository.Delete(id);
        }
        public IEnumerable<ScheduleEnum> GetAll()
        {
            return ICRUDRepository.GetAll();
        }
        public ScheduleEnum GetById(int id)
        {
            return ICRUDRepository.GetById(id);

        }
        public bool Update(ScheduleEnum t)
        {
            return ICRUDRepository.Update(t);

        }
    }
}
