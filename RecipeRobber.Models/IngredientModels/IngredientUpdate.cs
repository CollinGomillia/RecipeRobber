﻿using RecipeRobber.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeRobber.Models.IngredientModels
{
    public class IngredientUpdate
    {

        public int IngredientId { get; set; }

        public string Ingredients { get; set; }
      
        public string CustomaryUnit { get; set; }
     
        public double Measurement { get; set; }
      
       
    }
}
