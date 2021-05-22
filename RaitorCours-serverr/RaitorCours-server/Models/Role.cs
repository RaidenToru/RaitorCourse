using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaitorCours_server.Models
{
    public class Role
    {
        String RoleId { get; set; }
        String Code { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
