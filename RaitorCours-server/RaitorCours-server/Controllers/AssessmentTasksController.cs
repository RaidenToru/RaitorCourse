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
    public class AssessmentTasksController : ControllerBase
    {
        private readonly RaitorCoursDbContext _context;

        public AssessmentTasksController(RaitorCoursDbContext context)
        {
            _context = context;
        }

        // GET: api/AssessmentTasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssessmentTask>>> GetAssessmentTasks()
        {
            return await _context.AssessmentTasks.ToListAsync();
        }

        // GET: api/AssessmentTasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AssessmentTask>> GetAssessmentTask(int id)
        {
            var assessmentTask = await _context.AssessmentTasks.FindAsync(id);

            if (assessmentTask == null)
            {
                return NotFound();
            }

            return assessmentTask;
        }

        // PUT: api/AssessmentTasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssessmentTask(int id, AssessmentTask assessmentTask)
        {
            if (id != assessmentTask.AssessmentTaskId)
            {
                return BadRequest();
            }

            _context.Entry(assessmentTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssessmentTaskExists(id))
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

        // POST: api/AssessmentTasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AssessmentTask>> PostAssessmentTask(AssessmentTask assessmentTask)
        {
            _context.AssessmentTasks.Add(assessmentTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssessmentTask", new { id = assessmentTask.AssessmentTaskId }, assessmentTask);
        }

        // DELETE: api/AssessmentTasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssessmentTask(int id)
        {
            var assessmentTask = await _context.AssessmentTasks.FindAsync(id);
            if (assessmentTask == null)
            {
                return NotFound();
            }

            _context.AssessmentTasks.Remove(assessmentTask);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AssessmentTaskExists(int id)
        {
            return _context.AssessmentTasks.Any(e => e.AssessmentTaskId == id);
        }
    }
}
