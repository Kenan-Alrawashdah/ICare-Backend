using ICare.Core.ApiDTO;
using ICare.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ICare.Core.IRepository
{
    public interface ICartRepository
    {
        bool AddQuantity(int cartId);
        Task<bool> CheckItemExist(int patientId, int drugId);
        bool Create(Cart cart);
        bool Delete(int cartId);
        Task<IEnumerable<GetCartItemsApiDTO.Response>> GetCartItems(int userId);
        bool MinusQuantity(int cartId);
    }
}
