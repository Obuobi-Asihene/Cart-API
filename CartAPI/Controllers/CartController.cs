using CartAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CartAPI.Controllers
{
    [Route("/")]
    [ApiController]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly ICartFilterService _filterService;
        public CartController(ICartService cartService, ICartFilterService filterService)
        {
            _cartService = cartService;
            _filterService = filterService;
        }

        //add cart item
        [HttpPost("AddCartItem")]
        public IActionResult AddcartItem(int id, int quantity, string phoneNumber)
        {
            _cartService.AddCartItem(id, quantity, phoneNumber);
            return Ok("Item added to cart");
        }

        //remove cart item
        [HttpDelete("DeleteCartItem/{id}")]
        public IActionResult DeleteCartItem(int itemId)
        {
            _cartService.RemoveCartItem(itemId);
            return Ok("Cart Item Removed");
        }

        //list cart items
        [HttpGet("AllCartItems")]
        public IActionResult ListCartItems(string? phoneNumber = null, DateTime? CreatedAt = null, int? Quantity = null, string? item = null)
        {
            var cartItems = _cartService.ListCartItems();

            var filterCartItems = _filterService.FilterCartItems(cartItems, phoneNumber, CreatedAt, Quantity, item);                                              
            
            return Ok(filterCartItems);
        }
    }
}
