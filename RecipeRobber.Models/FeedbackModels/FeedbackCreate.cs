using RecipeRobber.Models.RecipeModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeRobber.Models.FeedbackModels
{
    public class FeedbackCreate
    {
        [Required]
        public string Comment { get; set; }
        [Required]
        public int Rating { get; set; }

        [Required]
        public int RecipeId { get; set; }
        public RecipeGet RecipeGet { get; set; }
    }
}
