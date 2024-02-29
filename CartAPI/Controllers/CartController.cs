using CartAPI.Models;
using CartAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CartAPI.Controllers
{
    [Route("/")]
    [ApiController]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        //add cart item
        [HttpPost("AddCartItem")]
        public IActionResult AddcartItem(Cart cartItem)
        {
            _cartService.AddCartItem(cartItem);
            return View(cartItem);
        }

        //remove cart item
        [HttpDelete("DeleteCartItem/{id}")]
        public IActionResult DeleteCartItem(int itemId)
        {
            var cartItem = _cartService.GetCartItem(itemId);
            if (cartItem == null)
            {
                return NotFound();
            }

            _cartService.RemoveCartItem(itemId);
            return Ok("Cart Item Removed");
        }

        //get cart item
        [HttpGet("GetCartItem/{id}")]
        public IActionResult GetCartItem(int itemId)
        {
            var cartItem = _cartService.GetCartItem(itemId);
            if ( cartItem == null)
            {
                return NotFound();
            }
            return Ok(cartItem);
        }

        //list cart items
        [HttpGet("AllCartItems")]
        public IActionResult ListCartItems()
        {
            var cartItems = _cartService.ListCartItems();
            return Ok(cartItems);
        }
    }
}
