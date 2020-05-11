using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string Duration { get; set; }
        public DateTime CreatedAt { get; set; }
        public Category Category { get; set; }
        public Complexity Complexity { get; set; }
        public ICollection <Like> Likes { get; set; }
    }
}
