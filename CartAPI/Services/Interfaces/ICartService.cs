using CartAPI.Models;

namespace CartAPI.Services.Interfaces
{
    public interface ICartService
    {
        void AddCartItem(Cart item);
        void RemoveCartItem(int itemId);
        IEnumerable<Cart> ListCartItems();
        Cart GetCartItem(int itemId);
    }
}
