using Microsoft.EntityFrameworkCore;
using raitorcours_server.Controllers;
using raitorcours_server.Models;
using RaitorCours_server.Data;
using RaitorCours_server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace raitorcours_test
{
    public class CoursesControllerTest
    {
        [Fact]
        public async Task GetCourses()
        {
            var options = new DbContextOptionsBuilder<RaitorCoursDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new RaitorCoursDbContext(options);

            var course = GetTestCourse();

            InsertCourse(context, course);

            var controller = new CoursesController(context);

            var result = await controller.GetCourses("", "");

            Assert.False(result.Value.Count() == 0);
        }

        [Fact]
        public async Task CreateCourse()
        {
            var options = new DbContextOptionsBuilder<RaitorCoursDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new RaitorCoursDbContext(options);

            var course = GetTestCourse();

            var controller = new CoursesController(context);

            await controller.PostCourse(course);

            var courseFromDb = context.Courses.Find(course.CourseId);

            Assert.NotNull(courseFromDb);
            Assert.Equal(courseFromDb.CourseName, course.CourseName);
        }

        [Fact]
        public async Task DeleteCourse()
        {
            var options = new DbContextOptionsBuilder<RaitorCoursDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new RaitorCoursDbContext(options);

            var course = GetTestCourse();

            InsertCourse(context, course);

            var controller = new CoursesController(context);

            await controller.DeleteCourse(course.CourseId);

            var courseFromDb = context.Courses.Find(course.CourseId);

            Assert.Null(courseFromDb);
        }

        [Fact]
        public async Task PutCourse()
        {
            var options = new DbContextOptionsBuilder<RaitorCoursDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new RaitorCoursDbContext(options);

            var course = GetTestCourse();

            InsertCourse(context, course);

            course.CourseName = "Another name";
            var controller = new CoursesController(context);
            await controller.PutCourse(course.CourseId, course);

            var courseFromDb = context.Courses.Find(course.CourseId);

            Assert.NotNull(courseFromDb);
            Assert.Equal(course.CourseName, courseFromDb.CourseName);
        }

        private Role GetTestRole()
        {
            return new Role()
            {
                RoleId = 1,
                Code = "USER"
            };

        }

        private User GetTestUser()
        {
            return new User()
            {
                UserId = 1,
                FirstName = "name",
                LastName = "name",
                Login = "login",
                Password = "pass",
                Role = GetTestRole()
            };

        }

        private Course GetTestCourse()
        {
            return new Course()
            {
                CourseId = 1,
                CourseName = "name",
                Price = 100,
                Rating = 5,
                Author = GetTestUser()
            };

        }

        private Course GetTestCourseAnother()
        {
            return new Course()
            {
                CourseId = 2,
                CourseName = "second",
                Price = 200,
                Rating = 3,
                Author = GetTestUser()
            };

        }

        private void InsertCourse(RaitorCoursDbContext context, Course course)
        {
            context.Courses.Add(course);
            context.SaveChanges();
        }
    }
}
