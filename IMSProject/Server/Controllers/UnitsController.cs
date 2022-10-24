using IMSProject.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IMSProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitsController : ControllerBase
    {
        private readonly DataContext _context;

        public UnitsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Unit>>> GetUnit()
        {
            var units = await _context.Units.ToListAsync();
            return Ok(units);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Unit>> GetSingleUnit(int id)
        {
            var units = await _context.Units
                .FirstOrDefaultAsync(u => u.Id == id);
            if (units == null)
            {
                return NotFound("Sorry, no unit here. :/");
            }
            return Ok(units);
        }

        [HttpPost]
        public async Task<ActionResult<List<Unit>>> CreateUnit(Unit unit)
        {
            _context.Units.Add(unit);
            await _context.SaveChangesAsync();
            return Ok(await GetDbUnits());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Unit>>> UpdateUnit(Unit unit, int id)
        {
            var dbunit = await _context.Units.FirstOrDefaultAsync(unit => unit.Id == id);
            if (dbunit == null)
                return NotFound("Sorry, but unit for you");
            dbunit.Type = unit.Type;
            dbunit.UpdatedBy = unit.UpdatedBy;
            dbunit.UdatedAt = unit.UdatedAt;

            await _context.SaveChangesAsync();
            return Ok(await GetDbUnits());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Unit>>> DeleteUnit(int id)
        {
            var dbunit = await _context.Units.FirstOrDefaultAsync(unit => unit.Id == id);
            if (dbunit== null)
                return NotFound("Sorry, but no Group for you");

            _context.Units.Remove(dbunit);
            await _context.SaveChangesAsync();
            return Ok(await GetDbUnits());
        }

        private async Task<List<Unit>> GetDbUnits()
        {
            return await _context.Units.ToListAsync();
        }
    }
}
