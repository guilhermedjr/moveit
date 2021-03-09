using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Challenge
    {
        public int ChallengeId { get; set; }
        public string Description { get; set; }
        public int XP { get; set; }
        public ChallengeType ChallengeType { get; set; } 
        public int ChallengeTypeId { get; set; }
        public List<ChallengeUser> ChallengeUsers { get; set; }

        public Challenge(int challengeId, string description, int xp, ChallengeType challengeType)
        {
            this.ChallengeId = challengeId;
            this.Description = description;
            this.XP = xp;
            this.ChallengeType = challengeType;
        }

        public Challenge() { }
    }
}
