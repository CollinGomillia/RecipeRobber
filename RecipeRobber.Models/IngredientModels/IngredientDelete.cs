﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeRobber.Models.IngredientModels
{
    public class IngredientDelete
    {
        public int IngredientId { get; set; }
        public int RecipeId { get; set; }
        public Guid OwnerId { get; set; }

    }
}
