using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Repository
{
    public class ContactMessageRepository : RepositoryBase<ContactMessage>, IContactMessageRepository
    {
        public ContactMessageRepository(RecipeDbContextController repositoryContext) : base(repositoryContext)
        {
        }
    }
}
