using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaitorCours_server.Models
{
    public class Subcategory
    {
        public int SubcategoryId { get; set; }
        public string SubcategoryName { get; set; }
        public Category Category { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
