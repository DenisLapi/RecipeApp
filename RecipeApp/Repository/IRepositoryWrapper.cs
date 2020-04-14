using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Repository
{
    public interface IRepositoryWrapper
    {
        ICategoryRepository Category { get; }
        void Save();
    }
}
