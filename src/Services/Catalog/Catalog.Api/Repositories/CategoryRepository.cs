using Catalog.Api.Data;
using Catalog.Api.Models;
using Catalog.Api.Shared;

namespace Catalog.Api.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>
    {
        public CategoryRepository(CatalogContext _context) : base(_context)
        {

        }
    }
}
