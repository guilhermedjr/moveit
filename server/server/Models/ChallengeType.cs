﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class ChallengeType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Challenge> Challenges { get; set; }

        public ChallengeType(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public ChallengeType() { }
    }
}
