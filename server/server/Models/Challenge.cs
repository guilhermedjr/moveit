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
        public List<ChallengeUser> ChallengeUsers { get; set; }
    }
}
