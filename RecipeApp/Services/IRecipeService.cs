using Microsoft.AspNetCore.Mvc;
using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp
{
    public interface IRecipeService
    {
        public List<Recipe> GetAll();

        public Recipe Details(int? id);

        public bool Add(Recipe recipe, string category, string complexity);

        public Recipe GetEdit(int? id);

        public bool Edit(Recipe recipe);

        public Recipe GetDelete(int? id);

        public bool Delete(int id);
    }
}
