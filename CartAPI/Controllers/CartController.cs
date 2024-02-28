using CartAPI.Data;
using CartAPI.Models;
using Microsoft.AspNetCore.Mvc;

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

       
    }
}
