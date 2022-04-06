using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeRobber.Models.IngredientModels
{
    public class IngredientGet
    {
        public int IngredientId { get; set; }
        public string Ingredients { get; set; }
        public string CustomaryUnit { get; set; }
        public double Measurement { get; set; }
        public int RecipeId { get; set; }
    }
}
