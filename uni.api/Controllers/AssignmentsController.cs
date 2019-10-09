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
    public class AssignmentsController : ControllerBase
    {
        private readonly unidb01Context _context;

        public AssignmentsController(unidb01Context context)
        {
            _context = context;
        }

        // GET: api/Assignments
        [HttpGet]
        public IEnumerable<StudentAssignment> GetStudentAssignment()
        {
            return _context.StudentAssignment;
                //.Include(a => a.Assign)
                //.Include(m => m.Assign.Mod)
                //.Include(c => c.Assign.Mod.Cours);

        }

        // GET: api/Assignments/5
        [HttpGet("{id}")]
        //       public async Task<ActionResult<StudentAssignment>> GetStudentAssignment(int id)
        //       {
        //           var studentAssignment = await _context.StudentAssignment.FindAsync(id);

        //           if (studentAssignment == null)
        //           {
        //               var query =
        //   from Assignment in _context.Assignment
        //   join Student in _context.Student on new { ModID = Convert.ToInt32(_context.Assignment.ModID) } equals new { ModID = id }
        //   select new
        //   {
        //       Assignment.AssignID,
        //       Student.FName,
        //       Assignment.AssignName,
        //       Assignment.EndDate
        //   };
        //}
        //           return studentAssignment;
        //       }

        public async Task<ActionResult<StudentAssignment>> GetStudentAssignment(int id)
        {
            var studentAssignment = await _context.StudentAssignment.FindAsync(id);

            if (studentAssignment == null)
            {
                return NotFound();
            }

            return studentAssignment;
        }

        // PUT: api/Assignments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentAssignment(int id, StudentAssignment studentAssignment)
        {
            if (id != studentAssignment.StuAssignId)
            {
                return BadRequest();
            }

            _context.Entry(studentAssignment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentAssignmentExists(id))
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

        // POST: api/Assignments
        [HttpPost]
        public async Task<ActionResult<StudentAssignment>> PostStudentAssignment(StudentAssignment studentAssignment)
        {
            _context.StudentAssignment.Add(studentAssignment);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StudentAssignmentExists(studentAssignment.StuAssignId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStudentAssignment", new { id = studentAssignment.StuAssignId }, studentAssignment);
        }

        // DELETE: api/Assignments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StudentAssignment>> DeleteStudentAssignment(int id)
        {
            var studentAssignment = await _context.StudentAssignment.FindAsync(id);
            if (studentAssignment == null)
            {
                return NotFound();
            }

            _context.StudentAssignment.Remove(studentAssignment);
            await _context.SaveChangesAsync();

            return studentAssignment;
        }

        private bool StudentAssignmentExists(int id)
        {
            return _context.StudentAssignment.Any(e => e.StuAssignId == id);
        }
    }
}
