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
    public class ChallengeTypesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ChallengeTypesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ChallengeTypes
        //[Authorize(Roles = "dev")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChallengeType>>> GetChallengeType()
        {
            return await _context.ChallengeType.ToListAsync();
        }

        // GET: api/ChallengeTypes/5
        //[Authorize(Roles = "dev")]
        [HttpGet("{id}")]
        public async Task<ActionResult<ChallengeType>> GetChallengeType(int id)
        {
            var challengeType = await _context.ChallengeType.FindAsync(id);

            if (challengeType == null)
            {
                return NotFound();
            }

            return challengeType;
        }

        // POST: api/ChallengeTypes
        //[Authorize(Roles = "dev")]
        [HttpPost]
        public async Task<ActionResult<ChallengeType>> PostChallengeType([FromBody] ChallengeType challengeType)
        {
            _context.ChallengeType.Add(challengeType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChallengeType", new { id = challengeType.Id }, challengeType);
        }

        // PUT: api/ChallengeTypes
        //[Authorize(Roles = "dev")]
        [HttpPut]
        public async Task<IActionResult> PutChallengeType([FromBody] ChallengeType challengeType)
        {
            _context.Entry(challengeType).State = EntityState.Modified;

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

        // DELETE: api/ChallengeTypes/5
        //[Authorize(Roles = "dev")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChallengeType(int id)
        {
            var challengeType = await _context.ChallengeType.FindAsync(id);
            if (challengeType == null)
            {
                return NotFound();
            }

            _context.ChallengeType.Remove(challengeType);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
