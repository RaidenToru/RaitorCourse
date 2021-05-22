using raitorcours_server.Models;
using RaitorCours_server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace raitorcours_server.Repositories.impl
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(RaitorCoursDbContext context) : base(context)
        {
        }
    }
}
