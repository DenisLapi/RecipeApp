using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Services.User
{
    public interface IUserService
    {
        public void SetPhoto(ApplicationUser user, string photo);
    }
}
