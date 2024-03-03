using CartAPI.Models;

namespace CartAPI.Services.Interfaces
{
    public interface ICartFilterService
    {
        IEnumerable<Cart> FilterCartItems(IEnumerable<Cart> cartItems, string? phoneNumber = null, DateTime? CreatedAt = null, int? Quantity = null, string? item = null);
    }
}