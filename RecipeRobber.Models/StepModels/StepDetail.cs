using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeRobber.Models.StepModels
{
    public class StepDetail
    {
        [Key]
        public int StepId { get; set; }
        [Required]
        public string Instruction { get; set; }

    }
}
