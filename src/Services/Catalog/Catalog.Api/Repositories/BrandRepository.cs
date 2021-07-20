using Catalog.Api.Data;
using Catalog.Api.Models;
using Catalog.Api.Shared;

namespace Catalog.Api.Repositories
{
    public class BrandRepository : RepositoryBase<Brand>
    {
        public BrandRepository(CatalogContext _context) : base(_context)
        {

        }
    }
}
