using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    public class Like
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Recipe Recipe { get; set; }
    }
}
