using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using uni.api.Models;

namespace uni.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly unidb01Context _context;

        public StudentController(unidb01Context context)
        {
            _context = context;
        }

        // GET: api/Student
        [HttpGet]

        public IEnumerable<Student> GetStudent()
        {
            return _context.Student
            .Include(a => a.StudentAssignment);
        }

        // GET: api/Student/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent([FromRoute] int id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var student = await _context.Student.FindAsync(id);

            var student = await _context.Student
                .Include(r => r.Role)
                .FirstOrDefaultAsync(i => i.StuId == id);
                                       
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        // PUT: api/Student/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            if (id != student.StuId)
            {
                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
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

        // POST: api/Student
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            _context.Student.Add(student);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StudentExists(student.StuId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStudent", new { id = student.StuId }, student);
        }

        // DELETE: api/Student/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Student.Remove(student);
            await _context.SaveChangesAsync();

            return student;
        }

        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.StuId == id);
        }

        //This method gets courses against student IDs (not working properly)
        // GET api/students/3/course
        [HttpGet("{id:int}/course")]
        public async Task<IActionResult> GetCourses(int id)
        {
            var student = await _context.Student
                .Include(c => c.Cours)
                .FirstOrDefaultAsync(i => i.StuId == id);

            if (student == null)
                return NotFound();

            return Ok(student.Cours);
        }

        //This method gets assignments against student IDs (not working properly)
        // GET api/students/3/assignments
        [HttpGet("{id:int}/assignments")]
        public async Task<IActionResult> GetAssignments(int id)
        {
            var student = await _context.Student
                .Include(s => s.StudentAssignment)
                .FirstOrDefaultAsync(i => i.StuId == id);

            if (student == null)
                return NotFound();

            return Ok(student.StudentAssignment);
        }
    }
}
