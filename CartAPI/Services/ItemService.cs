using CartAPI.Data;
using CartAPI.Models;
using CartAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CartAPI.Services
{
    public class ItemService : IItemService
    {
        private readonly CartDbContext _context;

        public ItemService(CartDbContext context)
        {
            _context = context;
        }

        public async Task<Item> CreateItemAsync(Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            return item;
        }

        public async Task<Item> GetSingleItemAsync(int id)
        {
            return await _context.Items.FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}
