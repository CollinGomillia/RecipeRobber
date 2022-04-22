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
                    OwnerId = _userId,
                    CustomaryUnit = model.CustomaryUnit,
                    Measurement = model.Measurement,
                    Ingredients = model.Ingredients
                    
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Ingredients.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }     

        public IEnumerable<IngredientGet> GetIngredients()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                       .Ingredients
                       .Where(e => e.OwnerId == _userId)
                       .Select(
                             e=>
                                new IngredientGet
                                {
                                    IngredientId = e.IngredientId,
                                    Ingredients = e.Ingredients,
                                    CustomaryUnit = e.CustomaryUnit,
                                    Measurement = e.Measurement
                                  
                                }
                        );
                return query.ToArray();
            }
        }

        public IngredientDetail GetIngredientById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Ingredients
                        .Single(e => e.IngredientId == id && e.OwnerId == _userId);
                return
                    new IngredientDetail
                    {
                        IngredientId = entity.IngredientId,
                        Ingredients = entity.Ingredients,
                        Measurement = entity.Measurement,
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
                       .Single(e => e.IngredientId == model.IngredientId);

                entity.Ingredients = model.Ingredients;
                entity.Measurement = model.Measurement;
                entity.CustomaryUnit = model.CustomaryUnit;

                ctx.SaveChanges();

                return true;
            }
        }

        public bool DeleteIngredient(int ingredientId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                       .Ingredients
                       .Single(e => e.IngredientId == ingredientId);

                ctx.Ingredients.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
