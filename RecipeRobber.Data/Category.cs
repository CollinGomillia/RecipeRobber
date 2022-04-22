using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeRobber.Data
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string CategoryType { get; set; }
        [Required]
        public DateTimeOffset CreatedCat { get; set; }
        public DateTimeOffset? ModifiedCat { get; set; }
       // public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
    }
}
