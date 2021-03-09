using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Contexts;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChallengesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ChallengesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Challenges
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Challenge>>> GetChallenges()
        {
            return await _context.Challenge.ToListAsync();
        }

        // GET: api/Challenges/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Challenge>> GetChallenge(int id)
        {
            var challenge = await _context.Challenge.FindAsync(id);

            if (challenge == null)
            {
                return NotFound();
            }

            return challenge;
        }

        // POST: api/Challenges
        [HttpPost]
        public async Task<ActionResult<Challenge>> PostChallenge([FromBody] Challenge challenge)
        {
            _context.Challenge.Add(challenge);
             await _context.SaveChangesAsync();

            return CreatedAtAction("GetChallenge", new { id = challenge.ChallengeId }, challenge);
        }

        // PUT: api/Challenges/5
        [HttpPut]
        public async Task<IActionResult> PutChallenge([FromBody] Challenge challenge)
        {

            _context.Entry(challenge).State = EntityState.Modified;

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

        // PATCH: api/Challenges/5
        [HttpPatch]
        public async Task<IActionResult> PatchUser([FromBody] Challenge challenge)
        {

            _context.Entry(challenge).State = EntityState.Modified;

            try
            {
               return Ok(await _context.SaveChangesAsync());
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        // DELETE: api/Challenges/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChallenge(int id)
        {
            var challenge = await _context.Challenge.FindAsync(id);
            if (challenge == null)
            {
                return NotFound();
            }

            _context.Challenge.Remove(challenge);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
