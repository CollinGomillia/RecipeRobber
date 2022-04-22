using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeRobber.Models.RecipeModels
{
    public class RecipeDetail
    {
        [Key]
        public int RecipeId { get; set; }
        [Required]
        public string Maketime { get; set; }
        [Required]
        public string RecipeName { get; set; }
    }
}
