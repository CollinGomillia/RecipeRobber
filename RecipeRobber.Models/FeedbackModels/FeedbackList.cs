using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeRobber.Models.FeedbackModels
{
    public class FeedbackList
    {
        public int AuthorId { get; set; }
        public string Comment { get; set; }
        public int RecipeId { get; set; }
        public int Rating { get; set; }
        public Guid OwnerId { get; set; }
    }
}
