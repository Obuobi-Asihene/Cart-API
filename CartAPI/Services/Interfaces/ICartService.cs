using CartAPI.Models;

namespace CartAPI.Services.Interfaces
{
    public interface ICartService
    {
        void AddCartItem(CartDto item);
        void RemoveCartItem(int itemId);
        IEnumerable<CartDto> ListCartItems();
        CartDto GetCartItem(int itemId);
    }
}
