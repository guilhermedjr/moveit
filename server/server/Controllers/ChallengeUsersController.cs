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
        //[Authorize (Roles = "dev")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChallengeUser>>> GetChallengeUser()
        {
            return await _context.ChallengeUser.ToListAsync();
        }

        // GET: api/ChallengeUsers/5
        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<ChallengeUser>>> GetUserChallenges(int userId)
        {
            var challengesData = await 
                                  (from u in _context.User
                                   join uc in _context.ChallengeUser
                                   on u.UserId equals uc.User.UserId
                                   join c in _context.Challenge
                                   on uc.Challenge.ChallengeId equals c.ChallengeId
                                   join ct in _context.ChallengeType
                                   on c.ChallengeTypeId equals ct.Id
                                   where uc.User.UserId == userId
                                   select new ChallengeUser 
                                   { 
                                      ChallengeId = uc.ChallengeId,
                                      UserId = uc.UserId,
                                      ExecutionId = uc.ExecutionId,
                                      FinishHour = uc.FinishHour,
                                      Challenge = new Challenge 
                                      { 
                                         ChallengeId = c.ChallengeId,
                                         Description = c.Description,
                                         XP = c.XP,
                                         ChallengeType = new ChallengeType
                                         {
                                             Id = ct.Id,
                                             Name = ct.Name
                                         }
                                      }
                                   }).ToListAsync();

            if (challengesData == null)
              return NotFound();

            return challengesData;
        }

        // GET: api/ChallengeUsers/GetUserChallenge?userId=5&challengeId=5&executionId=5
        [HttpGet("GetUserChallenge")]
        public async Task<ActionResult<object>> GetUserChallenge(int userId, int challengeId, int executionId)
        {
            var challengeData = await
                                  (from u in _context.User
                                   join uc in _context.ChallengeUser
                                   on u.UserId equals uc.User.UserId
                                   join c in _context.Challenge
                                   on uc.Challenge.ChallengeId equals c.ChallengeId
                                   join ct in _context.ChallengeType
                                   on c.ChallengeTypeId equals ct.Id
                                   where uc.User.UserId == userId
                                   where uc.Challenge.ChallengeId == challengeId
                                   where uc.ExecutionId == executionId
                                   select new ChallengeUser
                                   {
                                       ChallengeId = uc.ChallengeId,
                                       UserId = uc.UserId,
                                       ExecutionId = uc.ExecutionId,
                                       FinishHour = uc.FinishHour,
                                       Challenge = new Challenge
                                       {
                                           ChallengeId = c.ChallengeId,
                                           Description = c.Description,
                                           XP = c.XP,
                                           ChallengeType = new ChallengeType
                                           {
                                               Id = ct.Id,
                                               Name = ct.Name
                                           }
                                       }
                                   }).ToListAsync();

            if (challengeData == null)
                return NotFound();

            return challengeData;
        }

        // POST: api/ChallengeUsers
        [HttpPost]
        public async Task<ActionResult<ChallengeUser>> PostChallengeUser([FromBody] ChallengeUser challengeUser)
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
              { userId = challengeUser.UserId,
                challengeId = challengeUser.ChallengeId,
                executionId = challengeUser.ExecutionId,
                finishHour = challengeUser.FinishHour });
        }
    }
}
