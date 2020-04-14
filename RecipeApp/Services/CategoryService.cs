using Microsoft.AspNetCore.Mvc;
using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Services
{
    public class CategoryService : ICategoryService
    {
        public IActionResult Create()
        {
            return View(await _context.Categorie.ToListAsync());
        }

        public Task<IActionResult> Create([Bind(new[] { "Id,Name" })] Category category)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> DeleteConfirmed(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> Details(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> Edit(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> Edit(int id, [Bind(new[] { "Id,Name" })] Category category)
        {
            throw new NotImplementedException();
        }

    }
}
