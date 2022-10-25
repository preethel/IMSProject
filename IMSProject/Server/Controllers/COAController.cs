using IMSProject.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IMSProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class COAController : ControllerBase
    {
        private readonly DataContext _context;

        public COAController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ChartOfAccount>>> GetCOAs()
        {
            var coas = await _context.chartOfAccounts.ToListAsync();
            return Ok(coas);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ChartOfAccount>> GetSingleCOA(int id)
        {
            var coas = await _context.chartOfAccounts
                .FirstOrDefaultAsync(u => u.Id == id);
            if (coas == null)
            {
                return NotFound("Sorry, but no Chart of Account for you");
            }
            return Ok(coas);
        }

        [HttpPost]
        public async Task<ActionResult<List<ChartOfAccount>>> CreateCOA(ChartOfAccount chartOfAccount)
        {
            _context.chartOfAccounts.Add(chartOfAccount);
            await _context.SaveChangesAsync();
            return Ok(await GetDbCOAs());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<ChartOfAccount>>> UpdateCOA(ChartOfAccount chartOfAccount, int id)
        {
            var dbCOA = await _context.chartOfAccounts.FirstOrDefaultAsync(coa => coa.Id == id);
            if (dbCOA == null)
                return NotFound("Sorry, but no Chart of Account for you");
            dbCOA.Name= chartOfAccount.Name;
            dbCOA.Type= chartOfAccount.Type;
            dbCOA.UdatedAt = chartOfAccount.UdatedAt;
            dbCOA.UpdatedBy = chartOfAccount.UpdatedBy;
            await _context.SaveChangesAsync();
            return Ok(await GetDbCOAs());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ChartOfAccount>>> DeleteCOA(int id)
        {
            var dbCOA = await _context.chartOfAccounts.FirstOrDefaultAsync(coa => coa.Id == id);
            if (dbCOA == null)
                return NotFound("Sorry, but no Chart of Account for you");

            _context.chartOfAccounts.Remove(dbCOA);
            await _context.SaveChangesAsync();
            return Ok(await GetDbCOAs());
        }

        private async Task<List<ChartOfAccount>> GetDbCOAs()
        {
            return await _context.chartOfAccounts.ToListAsync();
        }
    }
}
