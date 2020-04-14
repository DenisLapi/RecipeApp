using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Services
{
    public class CategoryService : ICategoryService 
    {
        private readonly RecipeDbContextController _context;

        public CategoryService(RecipeDbContextController context)
        {
            _context = context;
        }

        public async Task<bool> Add(Category category)
        {
            _context.Add(category);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Category> Details(int? id)
        {
            if (id == null)
            {
                return null;
            }

            Category _category = await _context.Categories.FirstOrDefaultAsync(m => m.Id == id);
            return _category;
        }

        public async Task<Category> GetEdit(int? id)
        {
            if (id == null)
            {
                return null;
            }

            Category _category = await _context.Categories.FindAsync(id);

            return _category;
        }

        public async Task<bool> Edit(Category category)
        {
            try
            {
                _context.Update(category);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(category.Id))
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

        public async Task<Category> GetDelete(int? id)
        {
            return await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<bool> Delete(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }

        public async Task<List<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}
