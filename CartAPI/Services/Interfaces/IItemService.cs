using CartAPI.Models;

namespace CartAPI.Services.Interfaces
{
    public interface IItemService
    {
        Task<Item> CreateItemAsync(Item item);
        Task<Item> GetSingleItemAsync(int id);
    }
}
