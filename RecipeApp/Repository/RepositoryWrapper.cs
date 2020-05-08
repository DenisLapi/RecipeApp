using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RecipeDbContextController _repoContext;
        private ICategoryRepository _category;
        private IComplexityRepository _complexity;
        private IContactMessageRepository _contactMessage;

        public RepositoryWrapper(RecipeDbContextController repositoryContext)
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

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
