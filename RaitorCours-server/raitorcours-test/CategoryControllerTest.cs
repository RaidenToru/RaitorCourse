using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using raitorcours_server.Controllers;
using raitorcours_server.Repositories;
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
    public class CategoryControllerTest
    {

        [Fact]
        public async Task GetCategories()
        {
            var options = new DbContextOptionsBuilder<RaitorCoursDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new RaitorCoursDbContext(options);

            var category = GetTestCategory();

            InsertCategories(context, category);

            var controller = new CategoriesController(context);

            var result = await controller.GetCategories("", "");

            Assert.False(result.Value.Count() == 0);
        }

        [Fact]
        public async Task CreateCategory()
        {
            var options = new DbContextOptionsBuilder<RaitorCoursDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new RaitorCoursDbContext(options);

            var category = GetTestCategory();

            var controller = new CategoriesController(context);

            await controller.PostCategory(category);

            var categoryFromDb = context.Categories.Find(category.CategoryId);

            Assert.NotNull(categoryFromDb);
            Assert.Equal(categoryFromDb.CategoryName, category.CategoryName);
        }

        [Fact]
        public async Task DeleteCategory()
        {
            var options = new DbContextOptionsBuilder<RaitorCoursDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new RaitorCoursDbContext(options);

            var category = GetTestCategory();

            InsertCategories(context, category);

            var controller = new CategoriesController(context);

            await controller.DeleteCategory(category.CategoryId);

            var categoryFromDb = context.Categories.Find(category.CategoryId);

            Assert.Null(categoryFromDb);
        }

        [Fact]
        public async Task PutCategory()
        {
            var options = new DbContextOptionsBuilder<RaitorCoursDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new RaitorCoursDbContext(options);

            var category = GetTestCategory();

            InsertCategories(context, category);

            category.CategoryName = "Another name";
            var controller = new CategoriesController(context);
            await controller.PutCategory(category.CategoryId, category);

            var categoryFromDb = context.Categories.Find(category.CategoryId);

            Assert.NotNull(categoryFromDb);
            Assert.Equal(category.CategoryName, categoryFromDb.CategoryName);
        }

        private Category GetTestCategory()
        {
            return new Category()
            {
                CategoryId=1, 
                CategoryName="Cat1"
            };

        }

        private void InsertCategories(RaitorCoursDbContext context, Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
        }
    }
}
