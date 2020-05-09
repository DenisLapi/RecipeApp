using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace RecipeApp.Models
{
    public class RecipeDbContext : IdentityDbContext
    {
        public RecipeDbContext(DbContextOptions<RecipeDbContext> options) : base(options)
        {

        }
        public DbSet <Recipe> Recipes { get; set; }
        public DbSet <Category> Categories { get; set; }
        public DbSet <Complexity> Complexities { get; set; }
        public DbSet <Like> Likes { get; set; }
        public DbSet <ContactMessage> ContactMessages { get; set; }
    }
}