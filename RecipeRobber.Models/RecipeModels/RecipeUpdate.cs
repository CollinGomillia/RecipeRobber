using RecipeRobber.Models.IngredientModels;
using RecipeRobber.Models.StepModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeRobber.Models.RecipeModels
{
    public class RecipeUpdate
    {
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public int MakeTime { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? ModifiedAt { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public IEnumerable<IngredientGet> Ingredients { get; set; }
        public IEnumerable<StepGet> Steps { get; set; }
    }
}
