using CartAPI.Models;
using CartAPI.Services.Interfaces;

namespace CartAPI.Services
{
    public class CartFIlterService : ICartFilterService
    {
        public IEnumerable<Cart> FilterCartItems(IEnumerable<Cart> cartItems, string? phoneNumber = null, DateTime? CreatedAt = null, int? Quantity = null, string? item = null)
        {
            // Apply filters
            if (!string.IsNullOrEmpty(phoneNumber))
            {
                cartItems = cartItems.Where(c => c.PhoneNumber == phoneNumber);
            }
            if (CreatedAt.HasValue)
            {
                cartItems = cartItems.Where(c => c.CreatedAt >= CreatedAt.Value);
            }
            if (Quantity.HasValue)
            {
                cartItems = cartItems.Where(c => c.Quantity == Quantity.Value);
            }
            if (!string.IsNullOrEmpty(item))
            {
                cartItems = cartItems.Where(c => c.ItemName.Contains(item, StringComparison.OrdinalIgnoreCase));
            }

            return cartItems;
        }
    }
}
