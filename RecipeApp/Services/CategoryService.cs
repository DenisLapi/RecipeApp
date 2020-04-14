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
    public class CategoryService : ICategoryService 
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public CategoryService(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public bool Add(Category category)
        {
            _repoWrapper.Category.Create(category);
            _repoWrapper.Save();
            return true;
        }

        public Category Details(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var _category = (Category) _repoWrapper.Category.FindByCondition(m => m.Id == id).ToList()[0];
            return _category;
        }

        public Category GetEdit(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var _category = (Category) _repoWrapper.Category.FindByCondition(m => m.Id == id).ToList()[0];

            return _category;
        }

        public bool Edit(Category category)
        {
            try
            {
                _repoWrapper.Category.Update(category);
                _repoWrapper.Save();
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

        public Category GetDelete(int? id)
        {
            return (Category) _repoWrapper.Category.FindByCondition(m => m.Id == id).ToList()[0];
        }

        public bool Delete(int id)
        {
            var category = (Category) _repoWrapper.Category.FindByCondition(m => m.Id == id).ToList()[0];

            _repoWrapper.Category.Delete(category);
            _repoWrapper.Save();

            return true;
        }

        private bool CategoryExists(int id)
        {
            var categories = _repoWrapper.Category.FindByCondition(e => e.Id == id).ToList();
            return categories.Count() > 0 ? true : false;
        }

        public List<Category> GetAll()
        {
            return _repoWrapper.Category.FindAll().ToList();
        }
    }
}
