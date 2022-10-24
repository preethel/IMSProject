using IMSProject.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IMSProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly DataContext _context;

        public ItemController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Item>>> GetItems()
        {
            var items = await _context.Items
                .Include(it => it.Category)
                .Include(it => it.Category.CategoryGroup)
                .Include(it => it.Unit).ToListAsync();
            return Ok(items);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<Item>>> GetSingleItems(int id)
        {
            var item = await _context.Items
                .Include(it => it.Category)
                .Include(it => it.Category.CategoryGroup)
                .Include(it => it.Unit)
                .FirstOrDefaultAsync(it => it.Id == id);
            if(item == null)
            {
                return NotFound("Sorry there is no items!");
            }
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<List<Item>>> CreateItem(Item item)
        {
            item.Category = null;
            item.Unit = null;
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            
            return Ok(await GetDbItems());

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Item>>> UpdateItem(Item item,int id)
        {
            var dbItem = await _context.Items
                .Include(it => it.Category)
                .Include(it => it.Category.CategoryGroup)
                .Include(it => it.Unit)
                .FirstOrDefaultAsync(item => item.Id == id);
            if (dbItem == null)
                return NotFound("Sorry, but no Item for you");
            dbItem.UdatedAt = item.UdatedAt;
            dbItem.UpdatedBy = item.UpdatedBy;
            dbItem.Title = item.Title;
            dbItem.Description = item.Description;
            dbItem.SellingPrice = item.SellingPrice;
            dbItem.Ammount = item.Ammount;
            dbItem.Quantity = item.Quantity;
            dbItem.CategoryId = item.CategoryId;
            dbItem.UnitId = item.UnitId;
            dbItem.Category.CategoryGroupId = item.Category.CategoryGroupId;

            await _context.SaveChangesAsync();
            return Ok(await GetDbItems());

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Item>>> DeleteItem(int id)
        {
            var dbItem = await _context.Items
                .Include(it => it.Category)
                .Include(it => it.Category.CategoryGroup)
                .Include(it => it.Unit)
                .FirstOrDefaultAsync(item => item.Id == id);
            if (dbItem == null)
                return NotFound("Sorry, but no Item for you");

            _context.Items.Remove(dbItem);

            await _context.SaveChangesAsync();
            return Ok(await GetDbItems());

        }

        private async Task<List<Item>> GetDbItems()
        {
            return await _context.Items
                .Include(it => it.Category)
                .Include(it => it.Category.CategoryGroup)
                .Include(it => it.Unit)
                .ToListAsync();
        }

    }
}
