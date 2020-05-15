using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeApp.Models;
using RecipeApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRepositoryWrapper _repoWrapper;
        private readonly ICategoryService _categoryService;
        private readonly IComplexityService _complexityService;

        public RecipeService(IRepositoryWrapper repoWrapper, ICategoryService categoryService, IComplexityService complexityService)
        {
            _repoWrapper = repoWrapper;
            _categoryService = categoryService;
            _complexityService = complexityService;
        }

        public bool Add(Recipe recipe, string category, string complexity)
        {
            int complexityID = Int32.Parse(complexity);
            int categoryID = Int32.Parse(category);
            recipe.ComplexityId = complexityID;
            recipe.CategoryId = categoryID;
            _repoWrapper.Recipe.Create(recipe);
            _repoWrapper.Save();
            return true;
        }

        public Recipe Details(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var _recipe = (Recipe) _repoWrapper.Recipe.FindByCondition(m => m.Id == id).Include(x => x.Category).Include(x => x.Complexity).ToList()[0];

            return _recipe;
        } 

        public Recipe GetEdit(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var _recipe = (Recipe) _repoWrapper.Recipe.FindByCondition(m => m.Id == id).ToList()[0];

            return _recipe;
        }

        public bool Edit(Recipe recipe)
        {
            try
            {
                _repoWrapper.Recipe.Update(recipe);
                _repoWrapper.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeExists(recipe.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            return true;
        }

        public Recipe GetDelete(int? id)
        {
            return (Recipe) _repoWrapper.Recipe.FindByCondition(m => m.Id == id).ToList()[0];
        }

        public bool Delete(int id)
        {
            var recipe = (Recipe) _repoWrapper.Recipe.FindByCondition(m => m.Id == id).ToList()[0];

            _repoWrapper.Recipe.Delete(recipe);
            _repoWrapper.Save();

            return true;
        }

        private bool RecipeExists(int id)
        {
            var recipes = _repoWrapper.Recipe.FindByCondition(e => e.Id == id).ToList();
            return recipes.Any();
        }

        public List<Recipe> GetAll()
        {
            return _repoWrapper.Recipe.FindAll().ToList();
        }
    }
}
