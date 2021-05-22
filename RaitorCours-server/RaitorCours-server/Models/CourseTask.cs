
namespace RaitorCours_server.Models
{
    public class CourseTask
    {
        public int CourseTaskId { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public int? SubthemeSubthemeId { get; set; }
        public Subtheme Subtheme { get; set; }
    }
}