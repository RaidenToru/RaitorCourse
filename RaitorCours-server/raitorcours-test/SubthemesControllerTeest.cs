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
    public class SubthemesControllerTeest
    {
        [Fact]
        public async Task GetSubthemes()
        {
            var options = new DbContextOptionsBuilder<RaitorCoursDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new RaitorCoursDbContext(options);

            var subtheme = GetTestSubtheme();

            InsertSubtheme(context, subtheme);

            var controller = new SubthemesController(context);

            var result = await controller.GetSubthemes();

            Assert.False(result.Value.Count() == 0);
        }

        [Fact]
        public async Task CreateSubtheme()
        {
            var options = new DbContextOptionsBuilder<RaitorCoursDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new RaitorCoursDbContext(options);

            var subtheme = GetTestSubtheme();

            var controller = new SubthemesController(context);

            await controller.PostSubtheme(subtheme);

            var subthemeFromDb = context.Subthemes.Find(subtheme.SubthemeId);

            Assert.NotNull(subthemeFromDb);
            Assert.Equal(subthemeFromDb.SubthemeName, subtheme.SubthemeName);
        }

        [Fact]
        public async Task DeleteSubtheme()
        {
            var options = new DbContextOptionsBuilder<RaitorCoursDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new RaitorCoursDbContext(options);

            var subtheme = GetTestSubtheme();

            InsertSubtheme(context, subtheme);

            var controller = new SubthemesController(context);

            await controller.DeleteSubtheme(subtheme.SubthemeId);

            var subthemeFromDb = context.Subthemes.Find(subtheme.SubthemeId);

            Assert.Null(subthemeFromDb);
        }

        [Fact]
        public async Task PutSubtheme()
        {
            var options = new DbContextOptionsBuilder<RaitorCoursDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new RaitorCoursDbContext(options);

            var subtheme = GetTestSubtheme();

            InsertSubtheme(context, subtheme);

            subtheme.SubthemeName = "Another name";
            var controller = new SubthemesController(context);
            await controller.PutSubtheme(subtheme.SubthemeId, subtheme);

            var subthemeFromDb = context.Subthemes.Find(subtheme.SubthemeId);

            Assert.NotNull(subthemeFromDb);
            Assert.Equal(subtheme.SubthemeName, subthemeFromDb.SubthemeName);
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

        private Subtheme GetTestSubtheme()
        {
            return new Subtheme()
            {
                SubthemeId = 1,
                SubthemeName = "name",
                WeekEnum = 5,
                Course = GetTestCourse()
            };

        }

        private void InsertSubtheme(RaitorCoursDbContext context, Subtheme subtheme)
        {
            context.Subthemes.Add(subtheme);
            context.SaveChanges();
        }
    }
}
