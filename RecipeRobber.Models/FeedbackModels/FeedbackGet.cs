using RecipeRobber.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeRobber.Models.FeedbackModels
{
    public class FeedbackGet
    {
        public int RecipeId { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public int AuthorId { get; set; }
        [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; }
    }
}
