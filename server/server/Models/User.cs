using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
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
        public int RoleId { get; set; }
        public int? Level { get; set; }
        public int? LevelExperience { get; set; }
        public List<ChallengeUser> UserChallenges { get; set; }
        public string avatar_url { get; set; }
        public string bio { get; set; }

        [NotMapped]
        public string Token { get; set; }
    }
}
