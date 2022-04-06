using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeRobber.Models.FeedbackModels
{
    public class FeedbackDelete
    {
        [Required]
        public int AuthorId { get; set; }
    }
}
