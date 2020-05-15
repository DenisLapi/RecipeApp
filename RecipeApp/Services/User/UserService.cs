using RecipeApp.Models;
using RecipeApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Services.User
{
    public class UserService : IUserService
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public UserService(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public void SetPhoto(ApplicationUser user, string photo)
        {
            user.Photo = photo;
            _repoWrapper.User.Update(user);
            _repoWrapper.Save();
        }
    }
}
