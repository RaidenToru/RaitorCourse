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
    public class CoursesController : ControllerBase
    {
        private readonly RaitorCoursDbContext _context;

        public CoursesController(RaitorCoursDbContext context)
        {
            _context = context;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses(String sortOrder, string searchString)
        {
            var courses = from c in _context.Courses
                          select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                courses = courses.Where(c => c.CourseName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "text_desc":
                    return await courses.OrderByDescending(c => c.CourseName).ToListAsync();
                case "price_asc":
                    return await courses.OrderByDescending(c => c.Price).ToListAsync();
                case "price_desc":
                    return await courses.OrderBy(c => c.Price).ToListAsync();
                case "rating_desc":
                    return await courses.OrderByDescending(c => c.Rating).ToListAsync();
                case "rating_asc":
                    return await courses.OrderBy(c => c.Rating).ToListAsync();
                default:
                    return await courses.OrderBy(c => c.CourseName).ToListAsync();
            }
            return await _context.Courses.ToListAsync();
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            return course;
        }

        // PUT: api/Courses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, Course course)
        {
            if (id != course.CourseId)
            {
                return BadRequest();
            }

            _context.Entry(course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
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

        // POST: api/Courses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourse", new { id = course.CourseId }, course);
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.CourseId == id);
        }
    }
}
