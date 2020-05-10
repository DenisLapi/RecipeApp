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
        public List<Category> GetAll();

        public Category Details(int? id);

        public bool Add(Category category);

        public Category GetEdit(int? id);

        public bool Edit(Category category);

        public Category GetDelete(int? id);

        public bool Delete(int id);
    }
}
