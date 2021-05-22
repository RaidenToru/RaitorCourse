using Microsoft.EntityFrameworkCore;
using raitorcours_server.Controllers;
using raitorcours_server.Models;
using RaitorCours_server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace raitorcours_test
{
    public class RoleControllerTest
    {
        [Fact]
        public async Task GetRoles()
        {
            var options = new DbContextOptionsBuilder<RaitorCoursDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new RaitorCoursDbContext(options);

            var category = GetTestRole();

            InsertRole(context, category);

            var controller = new RolesController(context);

            var result = await controller.GetRoles("", "");

            Assert.False(result.Value.Count() == 0);
        }

        [Fact]
        public async Task CreateRole()
        {
            var options = new DbContextOptionsBuilder<RaitorCoursDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new RaitorCoursDbContext(options);

            var role = GetTestRole();

            var controller = new RolesController(context);

            await controller.PostRole(role);

            var roleFromDb = context.Roles.Find(role.RoleId);

            Assert.NotNull(roleFromDb);
            Assert.Equal(roleFromDb.Code, role.Code);
        }

        [Fact]
        public async Task DeleteRole()
        {
            var options = new DbContextOptionsBuilder<RaitorCoursDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new RaitorCoursDbContext(options);

            var role = GetTestRole();

            InsertRole(context, role);

            var controller = new RolesController(context);

            await controller.DeleteRole(role.RoleId);

            var roleFromDb = context.Roles.Find(role.RoleId);

            Assert.Null(roleFromDb);
        }

        [Fact]
        public async Task PutRole()
        {
            var options = new DbContextOptionsBuilder<RaitorCoursDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new RaitorCoursDbContext(options);

            var role = GetTestRole();

            InsertRole(context, role);

            role.Code= "Another code";
            var controller = new RolesController(context);
            await controller.PutRole(role.RoleId, role);

            var roleFromDb = context.Roles.Find(role.RoleId);

            Assert.NotNull(roleFromDb);
            Assert.Equal(role.Code, roleFromDb.Code);
        }

        private Role GetTestRole()
        {
            return new Role()
            {
                RoleId = 1,
                Code = "USER"
            };

        }

        private void InsertRole(RaitorCoursDbContext context, Role role)
        {
            context.Roles.Add(role);
            context.SaveChanges();
        }
    }
}
