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

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
