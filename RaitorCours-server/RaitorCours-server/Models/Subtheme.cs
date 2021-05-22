using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RaitorCours_server.Models
{
    public class Subtheme
    {
        public int SubthemeId { get; set; }
        public string SubthemeName { get; set; }
        public int WeekEnum { get; set; }
        public Course Course { get; set; }
        public ICollection<AssessmentTask> AssessmentTasks { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }

}