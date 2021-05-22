using RaitorCours_server.Data;
using RaitorCours_server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace raitorcours_server.Repositories.impl
{
    public class SubthemeRepository : GenericRepository<Subtheme>, ISubthemesRepository
    {
        public SubthemeRepository(RaitorCoursDbContext context) : base(context)
        {
        }
    }
}
