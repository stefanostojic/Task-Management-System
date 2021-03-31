using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Task_Management_System.Data;
using Task_Management_System.Models;
using Task_Management_System.Validators;

namespace Task_Management_System.Controllers
{
    [Route("api/userRoles")]
    [ApiController]
    public class UserRolesController : Controller
    {
        private readonly TaskManagementSystemContext _context;

        public UserRolesController(TaskManagementSystemContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.UserRoles.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetUserRoles()
        {
            var userRoles = await _context.UserRoles.ToListAsync();
            return Ok(userRoles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserRoleById(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userRole = await _context.UserRoles
                .FirstOrDefaultAsync(m => m.ID == id);
            if (userRole == null)
            {
                return NotFound();
            }

            //return View(userRole);
            return Ok(userRole);
        }
        
        // GET: UserRoles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ID,Name")] UserRole userRole)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        userRole.ID = Guid.NewGuid();
        //        _context.Add(userRole);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(userRole);
        //}

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNewUserRole([FromBody] UserRole userRole)
        {
            UserRoleValidator validator = new UserRoleValidator();
            ValidationResult results = validator.Validate(userRole);

            if (results.IsValid)
            {
                userRole.ID = Guid.NewGuid();
                _context.Add(userRole);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(AddNewUserRole), new { id = userRole.ID }, userRole);
                //return Ok(userRole);
            }
            else
            {
                foreach (var failure in results.Errors)
                {
                    Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                }
                // results.ToString();
            }
            return BadRequest();
        }

        // GET: UserRoles/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userRole = await _context.UserRoles.FindAsync(id);
            if (userRole == null)
            {
                return NotFound();
            }
            return View(userRole);
        }

        // POST: UserRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut("{id}")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, UserRole userRole)
        {
            if (id != userRole.ID)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserRoleExists(userRole.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Ok(userRole);
            }
            return NoContent();
        }

        // GET: UserRoles/Delete/5
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var userRole = await _context.UserRoles
        //        .FirstOrDefaultAsync(m => m.ID == id);
        //    if (userRole == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(userRole);
        //}

        // POST: UserRoles/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserRole(Guid id)
        {
            try
            {
                var userRole = await _context.UserRoles.FindAsync(id);
                if (userRole == null)
                {
                    return NotFound();
                }

                _context.UserRoles.Remove(userRole);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }

        private bool UserRoleExists(Guid id)
        {
            return _context.UserRoles.Any(e => e.ID == id);
        }

        [HttpOptions]
        public IActionResult GetUserRolesOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }
    }
}
