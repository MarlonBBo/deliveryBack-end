using delivery.Model;
using delivery.Repository;
using Microsoft.AspNetCore.Mvc;

namespace delivery.Controllers
{
    [ApiController]
    [Route("/item")]
    public class ItemController : ControllerBase
    {
        private readonly IItemInterface _item;

        public ItemController(IItemInterface item)
        {
            _item = item;
        }

        [HttpPost("CreateItem")]
        public async Task<Items> CreateItem(Items item)
        {
            var Item = await _item.CreateItem(item);
            return Item;
        }

        [HttpGet("List")]
        public async Task<List<Items>> List()
        {
            var items = await _item.ListItems();
            return items;
        }
    }
}
