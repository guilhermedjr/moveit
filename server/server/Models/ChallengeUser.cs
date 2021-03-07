using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class ChallengeUser
    {
        public int ChallengeId { get; set; }
        public int UserId { get; set; }

        public Challenge Challenge { get; set; }
        public User User { get; set; }

        public int ExecutionId { get; set; }
        public DateTime FinishHour { get; set; }
    }
}
