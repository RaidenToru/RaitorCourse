
namespace RaitorCours_server.Models
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }
        public Question Question { get; set; }
        public User User { get; set; }
    }

}