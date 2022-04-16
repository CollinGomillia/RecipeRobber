using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeRobber.Data
{
    public class Feedback
    {
        [Key]
        public int AuthorId { get; set; }
        public Guid OwnerId { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "The comment can not have more than 200 characters")]
        public string Comment { get; set; }
        [Required]
        [Range(1,5, ErrorMessage = "The rating should be between 1 and 5 stars")]
        public int Rating { get; set; }

        [Required]
        [ForeignKey(nameof(Recipe))]
        public int RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
