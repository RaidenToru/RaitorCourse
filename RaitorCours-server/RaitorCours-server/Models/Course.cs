using System;
using System.Collections.Generic;

namespace RaitorCours_server.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Info { get; set; }
        public Single Price { get; set; }
        public Single Rating { get; set; }
        public int WeekNum { get; set; }
        public Subcategory Subcategory { get; set; }
        public User Author { get; set; }
        public ICollection<Subtheme> Subthemes { get; set; }
        public ICollection<CourseUser> CourseOfUsers { get; set; }
    }

}