using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public UserType Role { get; set; }
        public int? Level { get; set; }
        public int? LevelExperience { get; set; }
        public List<ChallengeUser> UserChallenges { get; set; }
    }
}
