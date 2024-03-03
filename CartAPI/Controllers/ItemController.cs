using CartAPI.Models;
using CartAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CartAPI.Controllers
{
    [Route("api/items")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem(Item item)
        {
            var createdItem = await _itemService.CreateItemAsync(item);

            return Ok(createdItem);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleItem(int id)
        {
            var item = await _itemService.GetSingleItemAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }
    }
}
