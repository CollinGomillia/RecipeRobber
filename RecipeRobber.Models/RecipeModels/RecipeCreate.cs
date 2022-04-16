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
        public string MakeTime { get; set; }
       
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? ModifiedAt { get; set; }

        [Required]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public string CategoryType { get; set; }
        [Required]
        public IList<int> IngredientId { get; set; }
        public IList<int> FeedbackId { get; set; }
        public IList<int> StepId { get; set; }
    }
}
