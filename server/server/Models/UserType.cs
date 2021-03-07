using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class UserType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
}
