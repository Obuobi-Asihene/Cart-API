using CartAPI.Data;
using CartAPI.Models;
using CartAPI.Services.Interfaces;

namespace CartAPI.Services
{
    public class CartService : ICartService
    {
        private readonly CartDbContext _cartDbContext;
        public CartService(CartDbContext cartDbContext)
        {
            _cartDbContext = cartDbContext;
        }
        public void AddCartItem(Cart item)
        {
            var existingItem = _cartDbContext.Carts.FirstOrDefault(c => c.ItemId == item.ItemId);
            if (existingItem != null)
            {
                existingItem.Quantity += item.Quantity;
                _cartDbContext.Carts.Update(existingItem);
            }
            else
            {
                _cartDbContext.Carts.Add(item);

            }
            _cartDbContext.SaveChanges();
        }

        public void RemoveCartItem(int itemId)
        {
            var cartItem = _cartDbContext.Carts.Find(itemId);
            if (itemId != null)
            {
                _cartDbContext.Carts.Remove(cartItem);
                _cartDbContext.SaveChanges();
            }
        }

        public Cart GetCartItem(int itemId)
        {
            return _cartDbContext.Carts.Find(itemId);
        }

        public IEnumerable<Cart> ListCartItems()
        {
            return _cartDbContext.Carts.ToList();
        }
    }
}
