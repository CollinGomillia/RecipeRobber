﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeRobber.Models.CategoryModels
{
    public class CategoryCreate
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryType { get; set; }
       
        

    }
}
