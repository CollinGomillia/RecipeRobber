using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeRobber.Models.RecipeModels
{
    public class RecipeDelete
    {
        [Required]
        public int RecipeId { get; set; }
        public string OwnerId { get; set; }
    }
}
