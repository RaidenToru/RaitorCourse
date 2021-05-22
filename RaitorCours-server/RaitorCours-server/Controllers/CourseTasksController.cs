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
    public class CourseTasksController : ControllerBase
    {
        private readonly RaitorCoursDbContext _context;

        public CourseTasksController(RaitorCoursDbContext context)
        {
            _context = context;
        }

        // GET: api/CourseTasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseTask>>> GetCourseTasks()
        {
            return await _context.CourseTasks.ToListAsync();
        }

        // GET: api/CourseTasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseTask>> GetCourseTask(int id)
        {
            var courseTask = await _context.CourseTasks.FindAsync(id);

            if (courseTask == null)
            {
                return NotFound();
            }

            return courseTask;
        }

        // PUT: api/CourseTasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourseTask(int id, CourseTask courseTask)
        {
            if (id != courseTask.CourseTaskId)
            {
                return BadRequest();
            }

            _context.Entry(courseTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseTaskExists(id))
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

        // POST: api/CourseTasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CourseTask>> PostCourseTask(CourseTask courseTask)
        {
            _context.CourseTasks.Add(courseTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourseTask", new { id = courseTask.CourseTaskId }, courseTask);
        }

        // DELETE: api/CourseTasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourseTask(int id)
        {
            var courseTask = await _context.CourseTasks.FindAsync(id);
            if (courseTask == null)
            {
                return NotFound();
            }

            _context.CourseTasks.Remove(courseTask);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CourseTaskExists(int id)
        {
            return _context.CourseTasks.Any(e => e.CourseTaskId == id);
        }
    }
}
