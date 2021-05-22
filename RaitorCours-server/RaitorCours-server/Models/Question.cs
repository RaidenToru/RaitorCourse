using System.Collections.Generic;


namespace RaitorCours_server.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public AssessmentTask Task { get; set; }
        public ICollection<Answer> Answers { get; set; }

    }

}