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
        public void AddCartItem(int itemId, int quantity, string phoneNumber)
        {
            var existingCartItem = _cartDbContext.Carts.FirstOrDefault(c => c.ItemId == itemId);
            var item = _cartDbContext.Items.Find(itemId);

            if (item != null)
            {
                if (existingCartItem != null)
                {
                    existingCartItem.Quantity += quantity;
                }
                else
                {
                    var cartItem = new Cart
                    {
                        ItemId = itemId,
                        ItemName = item.Name,
                        Quantity = quantity,
                        UnitPrice = item.Price,
                        PhoneNumber = phoneNumber
                    };
                    _cartDbContext.Carts.Add(cartItem);
                };
                _cartDbContext.SaveChanges();
            }
        }

        public void RemoveCartItem(int itemId)
        {
            var cartItem = _cartDbContext.Carts.FirstOrDefault(c => c.ItemId == itemId);
            if (cartItem != null)
            {
                _cartDbContext.Carts.Remove(cartItem);
                _cartDbContext.SaveChanges();
            }
        }
        public IEnumerable<Cart> ListCartItems()
        {
            return _cartDbContext.Carts.ToList();
        }
    }
}
