using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecipeApp.Models;
using RecipeApp.ViewModels;

namespace RecipeApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRecipeService _recipeService;
        private readonly IContactMessageService _contactMessage;
        private const int MAX_RECIPES = 3;

        public HomeController(ILogger<HomeController> logger, IRecipeService recipeService, IContactMessageService contactMessage)
        {
            _logger = logger;
            _recipeService = recipeService;
            _contactMessage = contactMessage;
        }

        public IActionResult Index()
        {
            HomeIndexViewModel homeIndexViewModel = new HomeIndexViewModel
            {
                Recipes = _recipeService.GetSome(MAX_RECIPES)
            };

            return View(homeIndexViewModel);
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateContactMessage(ContactMessage contactMessage)
        {
            _contactMessage.Add(contactMessage);
            return RedirectToAction(nameof(Index));
        }
    }
}
