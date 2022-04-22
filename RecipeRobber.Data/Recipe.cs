using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeRobber.Data
{
    public class Recipe
    {
        [Key]
        public int RecipeId { get; set; }

       
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string RecipeName { get; set; }
        [Required]
        public string MakeTime { get; set; }
        [Required]
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? ModifiedAt { get; set; }

      //  [ForeignKey("Category")]
      //  public int CategoryId { get; set; }
      //  public virtual Category Category { get; set; }
      //  public string CategoryType { get; set; }
      //  public virtual IList<Feedback> Feedbacks { get; set; }
      //  public virtual IList<Ingredient> Ingredients { get; set; }
      //  public virtual IList<Step> Steps { get; set; }
    }
}
