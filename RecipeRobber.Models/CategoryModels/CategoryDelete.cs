using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeRobber.Models.CategoryModels
{
    public class CategoryDelete
    {
        public string CategoryType { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}
