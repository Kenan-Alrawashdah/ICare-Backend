using ICare.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.IServices
{
    public interface ISubscriptionTypeServices
    {
        bool Create(SubscribeType subscribeType);

        bool Update(SubscribeType subscribeType);

        bool Delete(int id);

        SubscribeType GetById(int id);

        IEnumerable<SubscribeType> GetAll();
    }
}
