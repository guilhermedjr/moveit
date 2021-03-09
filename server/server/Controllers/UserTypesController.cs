using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Contexts;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTypesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserTypesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/UserTypes
        //[Authorize (Roles = "dev")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserType>>> GetUserType()
        {
            return await _context.UserType.ToListAsync();
        }

        // GET: api/UserTypes/5
        //[Authorize(Roles = "dev")]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserType>> GetUserType(int id)
        {
            var userType = await _context.UserType.FindAsync(id);

            if (userType == null)
            {
                return NotFound();
            }

            return userType;
        }

        // POST: api/UserTypes
        //[Authorize(Roles = "dev")]
        [HttpPost]
        public async Task<ActionResult<UserType>> PostUserType([FromBody] UserType userType)
        {
            _context.UserType.Add(userType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserType", new { id = userType.Id }, userType);
        }


        // PUT: api/UserTypes/5
        //[Authorize(Roles = "dev")]
        [HttpPut]
        public async Task<IActionResult> PutUserType([FromBody] UserType userType)
        {

            _context.Entry(userType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // DELETE: api/UserTypes/5
        //[Authorize(Roles = "dev")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserType(int id)
        {
            var userType = await _context.UserType.FindAsync(id);
            if (userType == null)
            {
                return NotFound();
            }

            _context.UserType.Remove(userType);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
