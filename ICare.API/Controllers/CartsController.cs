using ICare.Core.Data;
using ICare.Core.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartsController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(List<Cart>), StatusCodes.Status200OK)]
        public List<Cart> GetAllCart()
        {
            return _cartService.GetAll().ToList();
        }

        [HttpPost("Add")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public bool AddCart(Cart cart)
        {
            return _cartService.Create(cart);
        }

        [HttpDelete("Delete/{cartId:int}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public bool DeleteCart(int cartId)
        {
            return _cartService.Delete(cartId);
        }

        [HttpPut("Update")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public bool UpdateCart(Cart cart)
        {
            return _cartService.Update(cart);
        }

        [HttpPost("GetById/{cartId:int}")]
        [ProducesResponseType(typeof(Order), StatusCodes.Status200OK)]
        public Cart GetCartById(int cartId)
        {
            return _cartService.GetById(cartId);
        }
    }
}
