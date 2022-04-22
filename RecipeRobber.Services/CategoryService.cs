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
        private readonly Guid _userId;

        public CategoryService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCategory(CategoryCreate model)
        {
             var entity =
                new Category()
                {
                    OwnerId = _userId,
                    CategoryId = model.CategoryId,
                    CategoryType = model.CategoryType
                  
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Categories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CategoryGet> GetCategories()
        {
            using (var ctx = new ApplicationDbContext())
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

        public CategoryDetail GetCategoryById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Categories
                        .Single(e => e.CategoryId == id && e.OwnerId == _userId);
                return
                    new CategoryDetail
                    {
                        CategoryType = entity.CategoryType,
                        CategoryId = entity.CategoryId
                    };
            }
        }

        public bool DeleteCategory(int categoryId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                 var entity =
                    ctx
                    .Categories
                    .Single(e => e.CategoryId == categoryId);
                ctx.Categories.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
