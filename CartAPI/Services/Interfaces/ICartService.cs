using CartAPI.Models;

namespace CartAPI.Services.Interfaces
{
    public interface ICartService
    {
        void AddCartItem(int itemId, int quantity, string phoneNumber);
        void RemoveCartItem(int itemId);
        IEnumerable<Cart> ListCartItems();
    }
}
