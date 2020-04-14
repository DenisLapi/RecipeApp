using Microsoft.AspNetCore.Mvc;
using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp
{
    public interface ICategoryService
    {
        public Task<List<Category>> GetAll();

        public Task<Category> Details(int? id);

        public Task<bool> Add(Category category);

        public Task<Category> GetEdit(int? id);

        public Task<bool> Edit(Category category);

        public Task<Category> GetDelete(int? id);

        public Task<bool> Delete(int id);
    }
}
