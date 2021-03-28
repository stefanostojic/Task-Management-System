using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_Management_System.Data;
using Task_Management_System.Models;

namespace Task_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskGroupsController : ControllerBase
    {
        private readonly TaskManagementSystemContext _context;

        public TaskGroupsController(TaskManagementSystemContext context)
        {
            _context = context;
        }

        // GET: api/TaskGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskGroup>>> GetTaskGroups()
        {
            return await _context.TaskGroups.ToListAsync();
        }

        // GET: api/TaskGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskGroup>> GetTaskGroup(Guid id)
        {
            var taskGroup = await _context.TaskGroups.FindAsync(id);

            if (taskGroup == null)
            {
                return NotFound();
            }

            return taskGroup;
        }

        // PUT: api/TaskGroups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskGroup(Guid id, TaskGroup taskGroup)
        {
            if (id != taskGroup.ID)
            {
                return BadRequest();
            }

            _context.Entry(taskGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskGroupExists(id))
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

        // POST: api/TaskGroups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TaskGroup>> PostTaskGroup(TaskGroup taskGroup)
        {
            _context.TaskGroups.Add(taskGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaskGroup", new { id = taskGroup.ID }, taskGroup);
        }

        // DELETE: api/TaskGroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskGroup(Guid id)
        {
            var taskGroup = await _context.TaskGroups.FindAsync(id);
            if (taskGroup == null)
            {
                return NotFound();
            }

            _context.TaskGroups.Remove(taskGroup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaskGroupExists(Guid id)
        {
            return _context.TaskGroups.Any(e => e.ID == id);
        }
    }
}
