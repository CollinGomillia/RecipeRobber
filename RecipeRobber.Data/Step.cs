using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeRobber.Data
{
    public class Step
    {
        [Key]
        public int StepId { get; set; }

        public Guid OwnerId { get; set; }

        [Required]
        public string Instruction { get; set; }

        [Required]
        [ForeignKey(nameof(Recipe))]
        public int RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
