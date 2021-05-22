using System;

namespace RaitorCours_server.Models
{
    public class CourseUser
    {
        public int CourseUserId { get; set; }
        public int Mark { get; set; }
        public string Status { get; set; }
        public DateTime StartedDate { get; set; }
        public User User { get; set; }
        public Course Course { get; set; }
    }


}