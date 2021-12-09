using ICare.Core.ApiDTO;
using ICare.Core.Data;
using ICare.Core.IRepository;
using ICare.Core.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ICare.Infra.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public bool Create(Cart cart)
        {
            return _cartRepository.Create(cart);
        }

        public async Task<IEnumerable<GetCartItemsApiDTO.Response>> GetCartItems(int userId)
        {
            return await _cartRepository.GetCartItems(userId);

        }

        public bool Delete(int cartId)
        {
            return _cartRepository.Delete(cartId);
        }
        public async Task<bool> CheckItemExist(int patientId, int drugId)
        {
            return await _cartRepository.CheckItemExist(patientId, drugId);
        }

        public bool AddQuantity(int cartId)
        {
            return  _cartRepository.AddQuantity(cartId);
        }

        public bool MinusQuantity(int cartId)
        {
            return _cartRepository.MinusQuantity(cartId);
        }



        //public IEnumerable<Cart> GetAll()
        //{
        //    return _cartRepository.GetAll();
        //}

        //public Cart GetById(int cartId)
        //{
        //    return _cartRepository.GetById(cartId);
        //}

        //public bool Update(Cart cart)
        //{
        //    return _cartRepository.Update(cart);
        //}
    }
}
