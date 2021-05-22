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
    public class CourseUsersController : ControllerBase
    {
        private readonly RaitorCoursDbContext _context;

        public CourseUsersController(RaitorCoursDbContext context)
        {
            _context = context;
        }

        // GET: api/CourseUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseUser>>> GetCourseUsers()
        {
            return await _context.CourseUsers.ToListAsync();
        }

        // GET: api/CourseUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseUser>> GetCourseUser(int id)
        {
            var courseUser = await _context.CourseUsers.FindAsync(id);

            if (courseUser == null)
            {
                return NotFound();
            }

            return courseUser;
        }

        // PUT: api/CourseUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourseUser(int id, CourseUser courseUser)
        {
            if (id != courseUser.CourseUserId)
            {
                return BadRequest();
            }

            _context.Entry(courseUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseUserExists(id))
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

        // POST: api/CourseUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CourseUser>> PostCourseUser(CourseUser courseUser)
        {
            _context.CourseUsers.Add(courseUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourseUser", new { id = courseUser.CourseUserId }, courseUser);
        }

        // DELETE: api/CourseUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourseUser(int id)
        {
            var courseUser = await _context.CourseUsers.FindAsync(id);
            if (courseUser == null)
            {
                return NotFound();
            }

            _context.CourseUsers.Remove(courseUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CourseUserExists(int id)
        {
            return _context.CourseUsers.Any(e => e.CourseUserId == id);
        }
    }
}
