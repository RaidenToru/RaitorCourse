using RaitorCours_server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace raitorcours_server.Repositories.impl
{
    public class AssesmentTasksRepository : GenericRepository<AssesmentTask>, IAssesmentTasksRepository
    {
        public AssesmentTasksRepository(RaitorCoursDbContext context) : base(context)
        {
        }
    }
}
