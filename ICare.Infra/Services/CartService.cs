using ICare.Core.Data;
using ICare.Core.IRepository;
using ICare.Core.IServices;
using System;
using System.Collections.Generic;
using System.Text;

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

        public bool Delete(int cartId)
        {
            return _cartRepository.Delete(cartId);
        }

        public IEnumerable<Cart> GetAll()
        {
            return _cartRepository.GetAll();
        }

        public Cart GetById(int cartId)
        {
            return _cartRepository.GetById(cartId);
        }

        public bool Update(Cart cart)
        {
            return _cartRepository.Update(cart);
        }
    }
}
