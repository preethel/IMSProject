using IMSProject.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IMSProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class COFController : ControllerBase
    {
        private readonly DataContext _context;

        public COFController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<COFmodel>>> GetCOFs()
        {
            var cofs = await _context.COFmodels.ToListAsync();
            return Ok(cofs);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<COFmodel>> GetSingleCOF(int id)
        {
            var cofs = await _context.COFmodels
                .FirstOrDefaultAsync(u => u.Id == id);
            if (cofs == null)
            {
                return NotFound("Sorry, no Chart of Account here. :/");
            }
            return Ok(cofs);
        }

        [HttpPost]
        public async Task<ActionResult<List<COFmodel>>> CreateCOF(COFmodel cOFmodel)
        {
            _context.COFmodels.Add(cOFmodel);
            await _context.SaveChangesAsync();
            return Ok(await GetDbCOFs());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<COFmodel>>> UpdateCOF(COFmodel cOFmodel, int id)
        {
            var dbCOF = await _context.COFmodels.FirstOrDefaultAsync(cof => cof.Id == id);
            if (dbCOF == null)
                return NotFound("Sorry, but unit for you");
            dbCOF.Name= cOFmodel.Name;
            dbCOF.UdatedAt = cOFmodel.UdatedAt;
            dbCOF.UpdatedBy = cOFmodel.UpdatedBy;
            await _context.SaveChangesAsync();
            return Ok(await GetDbCOFs());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<COFmodel>>> DeleteCOF(int id)
        {
            var dbCOF = await _context.COFmodels.FirstOrDefaultAsync(cof => cof.Id == id);
            if (dbCOF == null)
                return NotFound("Sorry, but no Group for you");

            _context.COFmodels.Remove(dbCOF);
            await _context.SaveChangesAsync();
            return Ok(await GetDbCOFs());
        }

        private async Task<List<COFmodel>> GetDbCOFs()
        {
            return await _context.COFmodels.ToListAsync();
        }
    }
}
