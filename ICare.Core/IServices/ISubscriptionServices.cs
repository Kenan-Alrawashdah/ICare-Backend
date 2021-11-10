using ICare.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.IServices
{
    public interface ISubscriptionServices
    {
        bool Create(Subscription subscription);

        bool Update(Subscription subscription);

        bool Delete(int id);

        Subscription GetById(int id);

        IEnumerable<Subscription> GetAll();
    }
}
