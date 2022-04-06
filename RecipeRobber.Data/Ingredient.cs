using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeRobber.Data
{
    public class Ingredient
    {
        [Key]
        public int IngredientId { get; set; }
        [Required]
        public string Ingredients { get; set; }
        [Required]
        public string CustomaryUnit { get; set; }
        [Required]
        public double Measurement { get; set; }

    }
}
