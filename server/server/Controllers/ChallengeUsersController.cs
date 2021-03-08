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
    public class ChallengeUsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ChallengeUsersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ChallengeUsers
        [Authorize (Roles = "dev")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChallengeUser>>> GetChallengeUser()
        {
            return await _context.ChallengeUser.ToListAsync();
        }

        // GET: api/ChallengeUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<object>>> GetUserChallenges(int userId)
        {
            var challengesData = await 
                                  (from u in _context.User
                                   join uc in _context.ChallengeUser
                                   on u.UserId equals uc.User.UserId
                                   join c in _context.Challenge
                                   on uc.Challenge.ChallengeId equals c.ChallengeId
                                   where uc.User.UserId == userId
                                   select new { uc, c }).ToListAsync();

            if (challengesData == null)
              return NotFound();

            return challengesData;
        }

        [HttpGet("{id}?cId={challengeId}&eId={executionId}")]
        public async Task<ActionResult<object>> GetUserChallenge(int userId, int challengeId, int executionId)
        {
            var challengeData = await
                                  (from u in _context.User
                                   join uc in _context.ChallengeUser
                                   on u.UserId equals uc.User.UserId
                                   join c in _context.Challenge
                                   on uc.Challenge.ChallengeId equals c.ChallengeId
                                   where uc.User.UserId == userId
                                   where uc.Challenge.ChallengeId == challengeId
                                   where uc.ExecutionId == executionId
                                   select new { uc, c }).ToListAsync();

            if (challengeData == null)
                return NotFound();

            return challengeData;
        }

        // POST: api/ChallengeUsers
        [HttpPost]
        public async Task<ActionResult<ChallengeUser>> PostChallengeUser(ChallengeUser challengeUser)
        {
            _context.ChallengeUser.Add(challengeUser);

            try
            {
               await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw;
            }

            return CreatedAtAction("GetUserChallenge", new 
              { userId = challengeUser.User.UserId,
                challengeId = challengeUser.Challenge.ChallengeId,
                executionId = challengeUser.ExecutionId });
        }


        // PUT: api/ChallengeUsers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChallengeUser(int id, ChallengeUser challengeUser)
        {
            if (id != challengeUser.ChallengeId)
            {
                return BadRequest();
            }

            _context.Entry(challengeUser).State = EntityState.Modified;

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

        // DELETE: api/ChallengeUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChallengeUser(int id)
        {
            var challengeUser = await _context.ChallengeUser.FindAsync(id);
            if (challengeUser == null)
            {
                return NotFound();
            }

            _context.ChallengeUser.Remove(challengeUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
