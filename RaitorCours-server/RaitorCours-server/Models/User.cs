using raitorcours_server.Models;
using System;
using System.Collections.Generic;

namespace RaitorCours_server.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Bio { get; set; }
        public DateTime BirthDate { get; set; }
        public Role Role { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public ICollection<CourseUser> CourseOfUsers { get; set; }
        public ICollection<Course> Courses { get; set; }
    }

}