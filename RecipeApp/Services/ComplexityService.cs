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
    public class ComplexityService : IComplexityService
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public ComplexityService(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public bool Add(Complexity complexity)
        {
            _repoWrapper.Complexity.Create(complexity);
            _repoWrapper.Save();
            return true;
        }

        public Complexity Details(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var _complexity = (Complexity) _repoWrapper.Complexity.FindByCondition(m => m.Id == id).ToList()[0];
            return _complexity;
        }

        public Complexity GetEdit(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var _complexity = (Complexity) _repoWrapper.Complexity.FindByCondition(m => m.Id == id).ToList()[0];
            return _complexity;
        }

        public bool Edit(Complexity complexity)
        {
            try
            {
                _repoWrapper.Complexity.Update(complexity);
                _repoWrapper.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComplexityExists(complexity.Id))
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

        public Complexity GetDelete(int? id)
        {
            return (Complexity) _repoWrapper.Complexity.FindByCondition(m => m.Id == id).ToList()[0];
        }

        public bool Delete(int id)
        {
            var _complexity = (Complexity) _repoWrapper.Complexity.FindByCondition(m => m.Id == id).ToList()[0];

            _repoWrapper.Complexity.Delete(_complexity);
            _repoWrapper.Save();

            return true;
        }

        private bool ComplexityExists(int id)
        {
            var complexities = _repoWrapper.Complexity.FindByCondition(e => e.Id == id).ToList();
            return complexities.Any();
        }

        public List<Complexity> GetAll()
        {
            return _repoWrapper.Complexity.FindAll().ToList();
        }
    }
}
