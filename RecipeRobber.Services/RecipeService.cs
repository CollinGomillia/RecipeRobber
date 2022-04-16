using RecipeRobber.Data;
using RecipeRobber.Models.RecipeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeRobber.Services
{
    public class RecipeService
    {
        private readonly Guid _userId;

        public RecipeService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateRecipe(RecipeCreate model)
        {
            Recipe entity =
                new Recipe()
                {
                    OwnerId = _userId,
                    RecipeName = model.RecipeName,
                    MakeTime = model.MakeTime,
                    CategoryType = model.CategoryType
                    
                };

            using (var context = new ApplicationDbContext())
            {
                entity.Feedbacks = new List<Feedback>();
                entity.Ingredients = new List<Ingredient>();
                entity.Steps = new List<Step>();
                foreach (int id in model.FeedbackId)
                {
                    var feedback = context.Feedbacks.Find(id);
                    entity.Feedbacks.Add(feedback);
                }
                foreach (int id in model.IngredientId)
                {
                    var ingredient = context.Ingredients.Find(id);
                    entity.Ingredients.Add(ingredient);
                }
                foreach (int id in model.StepId)
                {
                    var step = context.Steps.Find(id);
                    entity.Steps.Add(step);
                }

                context.Recipes.Add(entity);
                return context.SaveChanges() == 1;
            }
        }

        public RecipeGet GetRecipeById(int Id)
        {
            using(var context = new ApplicationDbContext())
            {
                var entity =
                    context
                    .Recipes
                    .SingleOrDefault(e => Id == e.RecipeId && e.OwnerId == _userId);

                return
                    new RecipeGet
                    {
                        RecipeId = entity.RecipeId,
                        RecipeName = entity.RecipeName,
                        CreatedAt = entity.CreatedAt,
                        ModifiedAt = entity.ModifiedAt,
                        Ingredients = entity.Ingredients,
                        Steps = entity.Steps,
                        CategoryType = entity.CategoryType
                        
                    };
            }
        }

        public IEnumerable<RecipeList> GetRecipes()
        {
            using (var context = new ApplicationDbContext())
            {
                var query =
                    context
                           .Recipes
                           .Where(e => e.OwnerId == _userId)
                           .Select(
                                 e =>
                                     new RecipeList
                                     {
                                         RecipeId = e.RecipeId,
                                         RecipeName = e.RecipeName,
                                         CreatedAt = e.CreatedAt,
                                         ModifiedAt = e.ModifiedAt,
                                         CategoryId = e.CategoryId,
                                         CategoryType = e.CategoryType,
                                         Ingredients = e.Ingredients,
                                         Steps = e.Steps

                                         
                                     });
                return query.ToArray();
                        
            }
        }

        public bool UpdateRecipe(RecipeUpdate model)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity =
                    context
                    .Recipes
                    .Single(e => e.RecipeId == model.RecipeId && e.OwnerId == _userId);

                entity.RecipeId = model.RecipeId;
                entity.CreatedAt = model.CreatedAt;
                entity.ModifiedAt = model.ModifiedAt;
                entity.CategoryType = model.CategoryType;
                entity.Ingredients = (IList<Ingredient>)model.Ingredients;
                entity.Steps = (IList<Step>)model.Steps;


                return context.SaveChanges() == 1;
            }
        }

        public bool DeleteRecipe(int recipeId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                         .Recipes
                         .SingleOrDefault(e => e.RecipeId == recipeId && e.OwnerId == _userId);

                ctx.Recipes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public static void InsertToList(Ingredient item)
        {


            List<Ingredient> ingredients = new List<Ingredient>();

            ingredients.Add(item);


        }

        public static void DeleteFromList(Ingredient item)
        {



        }

        public void DisplayList(IList<Ingredient> ingredients)
        {
            foreach(Ingredient Ingredient in ingredients)
            {
                Console.WriteLine(Ingredient);


            }


        }
    }
}
