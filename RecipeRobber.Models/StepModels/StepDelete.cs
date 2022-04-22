using RecipeRobber.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeRobber.Models.StepModels
{
    public class StepDelete
    {
        [Required]
        public int StepId { get; set; }

     //   [Required]
       // [ForeignKey(nameof(Recipe))]
      //  public int RecipeId { get; set; }

      //  public string Instruction { get; set; }
    }
}
