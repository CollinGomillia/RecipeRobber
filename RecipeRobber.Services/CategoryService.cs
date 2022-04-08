using RecipeRobber.Data;
using RecipeRobber.Models.CategoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeRobber.Services
{
    public class CategoryService
    {
        public CategoryService() { }

        private readonly Guid _userId;

        public CategoryService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCategory(CategoryCreate model)
        {
            Category entity =
                new Category()
                {
                    CategoryType = model.CategoryType,
                    OwnerId = _userId
                };
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                ctx.Categories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CategoryGet> GetCategories()
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Categories
                    .Where(e => e.OwnerId == _userId)
                    .Select(e => new CategoryGet()
                    {
                        CategoryId = e.CategoryId,
                        CategoryType = e.CategoryType
                    });
                return query.ToArray();

            }
        }

        public bool DeleteCategory(int categoryId)
        {
            using(ApplicationDbContext ctx = new ApplicationDbContext())
            {
                Category entity =
                    ctx
                    .Categories
                    .Single(e => e.CategoryId == categoryId);
                ctx.Categories.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
