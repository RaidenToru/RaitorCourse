using RaitorCours_server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace raitorcours_server.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public String Code { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
