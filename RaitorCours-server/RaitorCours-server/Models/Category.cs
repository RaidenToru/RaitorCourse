
using System.Collections.Generic;

namespace RaitorCours_server.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Subcategory> Subcategories { get; set; }
    }

}