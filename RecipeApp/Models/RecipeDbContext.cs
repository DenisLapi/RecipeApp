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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Role seeds
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "1",
                    Name = "User",
                    NormalizedName = "User"
                },
                new IdentityRole
                {
                    Id = "2",
                    Name = "Administrator",
                    NormalizedName = "Admin"
                }
            );

            // Category seeds
            builder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Food"
                },
                new Category
                {
                    Id = 2,
                    Name = "Lunch"
                }
            );

            // Complexity seeds
            builder.Entity<Complexity>().HasData(
                new Complexity
                {
                    Id = 1,
                    Name = "Easy"
                },
                new Complexity
                {
                    Id = 2,
                    Name = "Hard"
                }
            );

            // Recipe seeds
            builder.Entity<Recipe>().HasData(
                new Recipe
                {
                    Id = 1,
                    Name = "Curry Salmon with Mango",
                    Content = "This is random content",
                    Duration = "50",
                    Photo = "https://images.media-allrecipes.com/userphotos/560x315/3286508.jpg",
                    CreatedAt = new DateTime(),
                    CategoryId = 1,
                    ComplexityId = 1
                },
                new Recipe
                {
                    Id = 2,
                    Name = "World's Best Lasagna",
                    Content = "This is random content",
                    Duration = "30",
                    Photo = "https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fimages.media-allrecipes.com%2Fuserphotos%2F3359675.jpg",
                    CreatedAt = new DateTime(),
                    CategoryId = 1,
                    ComplexityId = 1
                },
                new Recipe
                {
                    Id = 3,
                    Name = "Pantry Chicken Casserole",
                    Content = "This is random content",
                    Duration = "40",
                    Photo = "https://images.media-allrecipes.com/userphotos/560x315/7847380.jpg",
                    CreatedAt = new DateTime(),
                    CategoryId = 1,
                    ComplexityId = 1
                }
            );

        }
    }
}