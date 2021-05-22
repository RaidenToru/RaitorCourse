using raitorcours_server.Repositories.impl;
using RaitorCours_server.Data;
using RaitorCours_server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace raitorcours_server.Repositories
{
    public class CoursesRepository : GenericRepository<Course>, ICoursesRepository
    {
        public CoursesRepository(RaitorCoursDbContext context) : base(context)
        {
        }
    }
}
