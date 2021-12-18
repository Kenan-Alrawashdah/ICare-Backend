using ICare.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ICare.Core.IRepository
{
    public interface ISubscriptionTypeRepository
    {
        Task<IEnumerable<SubscribeType>> GetAll();
        Task<SubscribeType> GetById(int id);
    }
}
