
using System.Collections.Generic;

namespace RaitorCours_server.Models
{
    public class AssessmentTask
    {
        public int AssessmentTaskId { get; set; }
        public string AssessmentTaskName { get; set; }
        public string Description { get; set; }
        public int Mark { get; set; }
        public Subtheme Subtheme { get; set; }
        public ICollection<Question> Questions { get; set; }
    }


}