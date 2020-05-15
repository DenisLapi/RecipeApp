using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Photo { get; set; }
        public ICollection<Like> Likes { get; set; } 
    }
}
