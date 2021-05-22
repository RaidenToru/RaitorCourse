using Microsoft.EntityFrameworkCore;
using RaitorCours_server.Models;

namespace RaitorCours_server.Data
{
    public class RaitorCoursDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Subtheme> Subthemes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<CourseUser> CourseUsers { get; set; }
        public DbSet<AssessmentTask> AssessmentTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subcategory>()
                .HasOne(s=>s.Category)
                .WithMany(c=>c.Subcategories);
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Subcategory)
                .WithMany(s => s.Courses);
            modelBuilder.Entity<Course>()
                .HasOne(s => s.Author)
                .WithMany(a => a.Courses);
            modelBuilder.Entity<CourseUser>()
                .HasOne(cu => cu.Course)
                .WithMany(c => c.CourseOfUsers);
            modelBuilder.Entity<CourseUser>()
                .HasOne(cu => cu.User)
                .WithMany(u => u.CourseOfUsers);
            modelBuilder.Entity<Subtheme>()
                .HasOne(s => s.Course)
                .WithMany(c => c.Subthemes);
            modelBuilder.Entity<AssessmentTask>()
                .HasOne(at => at.Subtheme)
                .WithMany(s => s.AssessmentTasks);
            modelBuilder.Entity<Task>()
                .HasOne(t => t.Subtheme)
                .WithMany(s => s.Tasks);
            modelBuilder.Entity<Question>()
                .HasOne(q => q.Task)
                .WithMany(at => at.Questions);
            modelBuilder.Entity<Answer>()
                .HasOne(a => a.Question)
                .WithMany(q => q.Answers);
            modelBuilder.Entity<Answer>()
                .HasOne(a => a.User)
                .WithMany(u => u.Answers);
        }
    }
}