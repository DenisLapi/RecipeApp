using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecipeApp.Models;
using RecipeApp.ViewModels;

namespace RecipeApp.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class RecipesController : Controller
    {
        private readonly IRecipeService _recipeService;
        private readonly ICategoryService _categoryService;
        private readonly IComplexityService _complexityService;

        public RecipesController(IRecipeService recipeService, ICategoryService categoryService, IComplexityService complexityService)
        {
            _recipeService = recipeService;
            _categoryService = categoryService;
            _complexityService = complexityService;
        }

        // GET: Recipes
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            List<Recipe> _recipes = _recipeService.GetAll();
            return View(_recipes);
        }

        // GET: Recipes/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            var recipe = _recipeService.Details(id);

            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // GET: Recipes/Create
        public IActionResult Create()
        {
            RecipeCreateViewModel recipeCreateViewModel = new RecipeCreateViewModel
            {
                categories = _categoryService.GetAll(),
                complexities = _complexityService.GetAll()
            };

            return View(recipeCreateViewModel);
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Recipe recipe, string category, string complexity)
        {
            bool isCreated = false;

            if (ModelState.IsValid)
            {
                isCreated = _recipeService.Add(recipe, category, complexity);
            }

            if (isCreated)
            {
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        // GET: Recipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            RecipeCreateViewModel recipeCreateViewModel = new RecipeCreateViewModel
            {
                categories = _categoryService.GetAll(),
                complexities = _complexityService.GetAll(),
                recipe = _recipeService.GetEdit(id)
            };

            if (recipeCreateViewModel == null)
            {
                return NotFound();
            }

            return View(recipeCreateViewModel);
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Recipe recipe, string category, string complexity)
        {
            if (ModelState.IsValid)
            {
                var categoryId = Int32.Parse(category);
                var complexityId = Int32.Parse(complexity);

                recipe.CategoryId = categoryId;
                recipe.ComplexityId = complexityId;

                bool isEdited = _recipeService.Edit(recipe);

                if (isEdited)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(recipe);
        }

        // GET: Recipes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = _recipeService.GetDelete(id);

            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _recipeService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
