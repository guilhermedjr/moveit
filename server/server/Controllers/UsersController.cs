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
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [Authorize (Roles = "dev")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return await _context.User.ToListAsync();
        }

        // GET: api/Users/ById/5
        [Authorize (Roles = "dev")]
        [HttpGet("ById/{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // GET: api/Users/ByUsername/guilhermedjr
        [Authorize]
        [HttpGet("ByUsername/{username}")]
        public async Task<ActionResult<User>> GetUserByUsername(string username)
        {
            var user = await _context.User.SingleAsync(u => u.Username == username);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // GET: api/Users/Search/guilhermedjr
        [Authorize]
        [HttpGet("Search/{search}")]
        public async Task<ActionResult<IEnumerable<User>>> SearchUsers(string search)
        {
            var users = await _context.User.Where(u => EF.Functions.Like(u.Username, $"%{search}%"))
                         .ToListAsync();

            if (users == null)
             return NotFound();

            return users;
        }

        // POST: api/Users
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserById", new { id = user.UserId }, user);
        }

        // PUT: api/Users/5
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.UserId)
              return BadRequest();


            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // PATCH: api/Users/guilhermedjr
        [Authorize]
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchUser(int id, User user)
        {
           if (id != user.UserId)
            return BadRequest();

           if (!UserExists(id))
            return NotFound();

           _context.Entry(user).State = EntityState.Modified;

           try
           {
              return Ok(await _context.SaveChangesAsync());
           }
           catch (DbUpdateConcurrencyException)
           {
              throw;
           }
        }

        // DELETE: api/Users/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
              return NotFound();
    

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(u => u.UserId == id);
        }
    }
}
