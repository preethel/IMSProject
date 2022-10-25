using IMSProject.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IMSProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CGroupController : ControllerBase
    {
        private readonly DataContext _context;

        public CGroupController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]   
        public async Task<ActionResult<List<CategoryGroup>>> GetCGroup()
        {
            var cgroups = await _context.CategoryGroups.ToListAsync();
            return Ok(cgroups);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryGroup>> GetSingleCGroup(int id)
        {
            var cgroup = await _context.CategoryGroups
                .FirstOrDefaultAsync(h => h.Id == id);
            if (cgroup == null)
            {
                return NotFound("Sorry, no category group here. :/");
            }
            return Ok(cgroup);
        }

        [HttpPost]
        public async Task<ActionResult<List<CategoryGroup>>> CreateCGroup(CategoryGroup categoryGroup)
        {
            _context.CategoryGroups.Add(categoryGroup);
            await _context.SaveChangesAsync();
            return Ok(await GetDbCGroups());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<CategoryGroup>>> UpdateCGroup(CategoryGroup categoryGroup, int id)
        {
            var dbCG = await _context.CategoryGroups.FirstOrDefaultAsync(cg => cg.Id == id);
            if (dbCG == null)
                return NotFound("Sorry, no category group here.");
            dbCG.Title = categoryGroup.Title;
            dbCG.UpdatedBy = categoryGroup.UpdatedBy;
            dbCG.UdatedAt = categoryGroup.UdatedAt;
            await _context.SaveChangesAsync();
            return Ok(await GetDbCGroups());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<CategoryGroup>>> DeleteCGroup(int id)
        {
            var dbCG = await _context.CategoryGroups.FirstOrDefaultAsync(cg => cg.Id == id);
            if (dbCG == null)
                return NotFound("Sorry, no category group here.");

            _context.CategoryGroups.Remove(dbCG);
            await _context.SaveChangesAsync();
            return Ok(await GetDbCGroups());
        }

        private async Task<List<CategoryGroup>> GetDbCGroups()
        {
            return await _context.CategoryGroups.ToListAsync();
        }
    }
}
