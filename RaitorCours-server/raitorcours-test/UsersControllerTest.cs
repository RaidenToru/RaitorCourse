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
    public class UsersControllerTest
    {
        [Fact]
        public async Task GetUsers()
        {
            var options = new DbContextOptionsBuilder<RaitorCoursDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new RaitorCoursDbContext(options);

            var user = GetTestUser();

            InsertUser(context, user);

            var controller = new UsersController(context);

            var result = await controller.GetUsers("", "");

            Assert.False(result.Value.Count() == 0);
        }

        [Fact]
        public async Task CreateUser()
        {
            var options = new DbContextOptionsBuilder<RaitorCoursDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new RaitorCoursDbContext(options);

            var user = GetTestUser();

            var controller = new UsersController(context);

            await controller.PostUser(user);

            var userFromDb = context.Users.Find(user.UserId);

            Assert.NotNull(userFromDb);
            Assert.Equal(userFromDb.FirstName, user.FirstName);
            Assert.Equal(userFromDb.LastName, user.LastName);
            Assert.Equal(userFromDb.Login, user.Login);
        }

        [Fact]
        public async Task DeleteUser()
        {
            var options = new DbContextOptionsBuilder<RaitorCoursDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new RaitorCoursDbContext(options);

            var user = GetTestUser();

            InsertUser(context, user);

            var controller = new UsersController(context);

            await controller.DeleteUser(user.UserId);

            var userFromDb = context.Users.Find(user.UserId);

            Assert.Null(userFromDb);
        }

        [Fact]
        public async Task PutUser()
        {
            var options = new DbContextOptionsBuilder<RaitorCoursDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new RaitorCoursDbContext(options);

            var course = GetTestUser();

            InsertUser(context, course);

            course.FirstName = "Another name";
            course.LastName = "Last name";

            var controller = new UsersController(context);
            await controller.PutUser(course.UserId, course);

            var courseFromDb = context.Users.Find(course.UserId);

            Assert.NotNull(courseFromDb);
            Assert.Equal(course.FirstName, courseFromDb.FirstName);
            Assert.Equal(course.LastName, courseFromDb.LastName);
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

        private void InsertUser(RaitorCoursDbContext context, User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}
