using Catalog.Api.Data;
using Catalog.Api.Models;
using Catalog.Api.Shared;

namespace Catalog.Api.Repositories
{
    public class DepartmentRepository : RepositoryBase<Department>
    {
        public DepartmentRepository(CatalogContext _context) : base(_context)
        {

        }
    }
}
