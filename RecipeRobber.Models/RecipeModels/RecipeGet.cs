using RecipeRobber.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeRobber.Models.RecipeModels
{
    public class RecipeGet
    {
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public int MakeTime { get; set; }

        public string CategoryType { get; set; }


        public virtual ICollection<Ingredient> Ingredients { get; set; }
        public virtual ICollection<Step> Steps { get; set; }


        [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? ModifiedAt { get; set; }
    }
}
