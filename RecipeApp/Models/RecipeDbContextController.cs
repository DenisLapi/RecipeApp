using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace RecipeApp.Models
{
    public class RecipeDbContextController : DbContext
    {
        public RecipeDbContextController(DbContextOptions<RecipeDbContextController> options) : base(options)
        {

        }
        public DbSet <User> Users { get; set; }
        public DbSet <Role> Roles { get; set; }
        public DbSet <Recipe> Recipes { get; set; }
        public DbSet <Category> Categorie { get; set; }
        public DbSet <Complexity> Complexities { get; set; }
        public DbSet <Like> Likes { get; set; }
        public DbSet <ContactMessage> ContactMessages { get; set; }
    }
}