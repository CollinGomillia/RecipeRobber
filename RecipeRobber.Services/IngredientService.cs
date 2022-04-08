using RecipeRobber.Data;
using RecipeRobber.Models.IngredientModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeRobber.Services
{
    public class IngredientService
    {
        private readonly Guid _userId;

        public IngredientService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateIngredient(IngredientCreate model)
        {
            Ingredient entity =
                new Ingredient()
                {
                    CustomaryUnit = model.CustomaryUnit,
                    Measurement = model.Measurement,
                    Ingredients = model.Ingredients,
                    OwnerId = _userId
                };
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                ctx.Ingredients.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }     

        public IEnumerable<IngredientList> GetIngredients()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                       .Ingredients
                       .Where(e => e.OwnerId == _userId)
                       .Select(
                             e=>
                                new IngredientList
                                {
                                    IngredientId = e.IngredientId,
                                    Ingredients = e.Ingredients,
                                    CustomaryUnit = e.CustomaryUnit,
                                    Measurement = e.Measurement,
                                    RecipeId = e.RecipeId
                                }
                        );
                return query.ToArray();
            }
        }

        public IngredientGet GetIngredientById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Ingredients
                        .Single(e => e.IngredientId == id && e.OwnerId == _userId);
                return
                    new IngredientGet
                    {
                        IngredientId = entity.IngredientId,
                        Ingredients = entity.Ingredients,
                        Measurement = entity.Measurement,
                        RecipeId = entity.RecipeId,
                        CustomaryUnit = entity.CustomaryUnit
                    };
            }
        }

        public bool UpdateIngredient(IngredientUpdate model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                       .Ingredients
                       .Single(e => e.IngredientId == model.IngredientId && e.OwnerId == _userId);

                entity.Ingredients = model.Ingredients;
                entity.Measurement = model.Measurement;
                entity.CustomaryUnit = model.CustomaryUnit;

                return ctx.SaveChanges() == 1;

            }
        }

        public bool DeleteIngredient(int ingredientId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                       .Ingredients
                       .Single(e => e.IngredientId == ingredientId && e.OwnerId == _userId);

                ctx.Ingredients.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
