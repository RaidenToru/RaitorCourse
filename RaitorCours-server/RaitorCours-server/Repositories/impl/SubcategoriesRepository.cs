using RaitorCours_server.Data;
using RaitorCours_server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace raitorcours_server.Repositories.impl
{
    public class SubcategoriesRepository : GenericRepository<Subcategory>, ISubcategoriesRepository
    {
        public SubcategoriesRepository(RaitorCoursDbContext context) : base(context)
        {
        }
    }
}
