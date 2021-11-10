using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.IServices
{
    public interface ICRUDServices<T>
    {
        bool Create(T t);

        bool Update(T t);

        bool Delete(int id);

        T GetById(int id);

        IEnumerable<T> GetAll();
    }
}
