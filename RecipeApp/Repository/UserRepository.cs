using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Repository
{
    public class UserRepository : RepositoryBase<ApplicationUser>, IUserRepository
    {
        public UserRepository(RecipeDbContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
