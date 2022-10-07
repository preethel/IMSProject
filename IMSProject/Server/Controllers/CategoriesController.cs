using IMSProject.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IMSProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly DataContext _context;

        public CategoriesController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetCatagories()
        {
            var categories = await _context.Categories.Include(c => c.CategoryGroup).ToListAsync();
            return Ok(categories);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {
            var category = await _context.Categories
                .Include(c => c.CategoryGroup)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (category == null)
            {
                return NotFound("Sorry, no Category here. :/");
            }
            return Ok(category);
        }
        [HttpPost]
        public async Task<ActionResult<List<Category>>> CreateCategory(Category category)
        {
            category.CategoryGroup = null;
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return Ok(await GetDbCategories());
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Category>>> UpdateCategory(Category category, int id)
        {
            var dbCategory= await _context.Categories
                .Include(c => c.CategoryGroup)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (dbCategory == null)
                return NotFound("Sorry, but no Category for you. :/");

            dbCategory.Title = category.Title;
            dbCategory.Description= category.Description;
            dbCategory.CategoryGroupId= category.CategoryGroupId;
            
            await _context.SaveChangesAsync();

            return Ok(await GetDbCategories());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Category>>> DeleteCategory(int id)
        {
            var dbCategory = await _context.Categories
                .Include(c => c.CategoryGroup)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (dbCategory == null)
                return NotFound("Sorry, but no Category for you. :/");
            _context.Categories.Remove(dbCategory);
            await _context.SaveChangesAsync();

            return Ok(await GetDbCategories());
        }
        private async Task<List<Category>> GetDbCategories()
        {
            return await _context.Categories.Include(c => c.CategoryGroup).ToListAsync();
        }
    }
}
