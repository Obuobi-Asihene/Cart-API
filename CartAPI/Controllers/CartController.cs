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

        
    }
}
