using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaitorCours_server.Data;
using RaitorCours_server.Models;

namespace raitorcours_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubthemesController : ControllerBase
    {
        private readonly RaitorCoursDbContext _context;

        public SubthemesController(RaitorCoursDbContext context)
        {
            _context = context;
        }

        // GET: api/Subthemes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subtheme>>> GetSubthemes()
        {
            return await _context.Subthemes.ToListAsync();
        }

        // GET: api/Subthemes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Subtheme>> GetSubtheme(int id)
        {
            var subtheme = await _context.Subthemes.FindAsync(id);

            if (subtheme == null)
            {
                return NotFound();
            }

            return subtheme;
        }

        // PUT: api/Subthemes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubtheme(int id, Subtheme subtheme)
        {
            if (id != subtheme.SubthemeId)
            {
                return BadRequest();
            }

            _context.Entry(subtheme).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubthemeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Subthemes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Subtheme>> PostSubtheme(Subtheme subtheme)
        {
            _context.Subthemes.Add(subtheme);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubtheme", new { id = subtheme.SubthemeId }, subtheme);
        }

        // DELETE: api/Subthemes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubtheme(int id)
        {
            var subtheme = await _context.Subthemes.FindAsync(id);
            if (subtheme == null)
            {
                return NotFound();
            }

            _context.Subthemes.Remove(subtheme);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubthemeExists(int id)
        {
            return _context.Subthemes.Any(e => e.SubthemeId == id);
        }
    }
}
