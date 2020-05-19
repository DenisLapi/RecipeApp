using RecipeApp.Models;
using RecipeApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.ViewModels
{
    public class RecipeCreateViewModel
    {
        public List<Category> Categories { get; set; }
        public List<Complexity> Complexities { get; set; }
        public Recipe Recipe { get; set; }
    }
}
