using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.ViewModels
{
    public class HomeIndexViewModel
    {
        public List<Recipe> Recipes { get; set; }
        public ContactMessage ContactMessage { get; set;  }
    }
}
