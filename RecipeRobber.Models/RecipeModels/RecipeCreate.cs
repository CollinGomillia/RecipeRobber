using RecipeRobber.Models.FeedbackModels;
using RecipeRobber.Models.IngredientModels;
using RecipeRobber.Models.StepModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeRobber.Models.RecipeModels
{
    public class RecipeCreate
    {
        
        [Required]
        public string RecipeName { get; set; }
        [Required]
        public int MakeTime { get; set; }
        [Required]
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? ModifiedAt { get; set; }

        [Required]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public IEnumerable<IngredientGet> Ingredients { get; set; }
        public IEnumerable<FeedbackGet> Feedbacks { get; set; }
        public IEnumerable<StepGet> Steps { get; set; }
    }
}
