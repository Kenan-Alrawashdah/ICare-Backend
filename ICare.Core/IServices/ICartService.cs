using ICare.Core.ApiDTO;
using ICare.Core.Data;
using ICare.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ICare.Core.IServices
{
    public interface ICartService
    {
        bool AddQuantity(int cartId);
        Task<bool> CheckItemExist(int patientId, int drugId);
        bool Create(Cart cart);
        bool Delete(int cartId);
        Task<IEnumerable<GetCartItemsApiDTO.Response>> GetCartItems(int userId);
        bool MinusQuantity(int cartId);
        bool ChangeQuantity(int cartId, int Quantity);

    }
}
