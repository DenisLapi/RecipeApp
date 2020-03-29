using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    public class Complexity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Recipe> Recipes { get; set; }
    }
}
