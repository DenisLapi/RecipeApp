using Microsoft.AspNetCore.Mvc;
using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp
{
    public interface IComplexityService
    {
        public List<Complexity> GetAll();

        public Complexity Details(int? id);

        public bool Add(Complexity complexity);

        public Complexity GetEdit(int? id);

        public bool Edit(Complexity complexity);

        public Complexity GetDelete(int? id);

        public bool Delete(int id);
    }
}
