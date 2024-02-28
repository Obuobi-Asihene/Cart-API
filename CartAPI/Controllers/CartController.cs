using CartAPI.Data;
using CartAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CartAPI.Controllers
{
    public class CartController : Controller
    {
        private readonly CartDbContext _cartDbContext;
        public CartController(CartDbContext cartDbContext)
        {
            _cartDbContext = cartDbContext;
        }

        //Add cart item
        [HttpPost]
        public async Task<IActionResult> AddCartItem(Cart cartItem)
        {
            _cartDbContext.Carts.Add(cartItem);
            await _cartDbContext.SaveChangesAsync();

            return View(cartItem);
        }

        // get cart item
        [HttpGet]
        public IActionResult GetCarItems()
        {
            var cartItems = _cartDbContext.Carts.ToList();
            return Ok(cartItems);
        }

        //update cart item
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCartItem(Cart cartItem, int id)
        {
            var existingCartItem = await _cartDbContext.Carts.FindAsync(id);
            if (existingCartItem == null)
            {
                return NotFound();
            }

            existingCartItem.ItemName = cartItem.ItemName;
            existingCartItem.Quantity = cartItem.Quantity;
            existingCartItem.UnitPrice = cartItem.UnitPrice;

            await _cartDbContext.SaveChangesAsync();
            return View(existingCartItem);
            
        }
    }
}
