using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Repository
{
    public class ComplexityRepository : RepositoryBase<Complexity>, IComplexityRepository
    {
        public ComplexityRepository(RecipeDbContextController repositoryContext) : base(repositoryContext)
        {
        }
    }
}
