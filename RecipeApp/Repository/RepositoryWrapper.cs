using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly RecipeDbContext _repoContext;
        private ICategoryRepository _category;
        private IComplexityRepository _complexity;
        private IContactMessageRepository _contactMessage;
        private IRecipeRepository _recipe;
        private IUserRepository _user;

        public RepositoryWrapper(RecipeDbContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public ICategoryRepository Category
        {
            get
            {
                if (_category == null)
                {
                    _category = new CategoryRepository(_repoContext);
                }

                return _category;
            }
        }

        public IComplexityRepository Complexity
        {
            get
            {
                if (_complexity == null)
                {
                    _complexity = new ComplexityRepository(_repoContext);
                }

                return _complexity;
            }
        }

        public IContactMessageRepository ContactMessage
        {
            get
            {
                if (_contactMessage == null)
                {
                    _contactMessage = new ContactMessageRepository(_repoContext);
                }

                return _contactMessage;
            }
        }

        public IRecipeRepository Recipe
        {
            get
            {
                if (_recipe == null)
                {
                    _recipe = new RecipeRepository(_repoContext);
                }

                return _recipe;
            }
        }

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_repoContext);
                }

                return _user;
            }
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
