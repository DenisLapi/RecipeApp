using Microsoft.AspNetCore.Mvc;
using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp
{
    public interface ILikeService
    {
        public List<Like> GetAll();

        public Like Details(int? id);

        public bool Add(Like like);

        public Like GetEdit(int? id);

        public bool Edit(Like like);

        public Like GetDelete(int? id);

        public bool Delete(int id);
    }
}
