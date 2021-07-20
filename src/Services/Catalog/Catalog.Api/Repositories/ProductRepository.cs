using Catalog.Api.Data;
using Catalog.Api.Models;
using Catalog.Api.Shared;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Api.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        private readonly CatalogContext _context;
        public ProductRepository(CatalogContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetByBrand(int brandId)
        {
            return await _context.Products.Where(x => x.BrandId == brandId)
                .Include(x => x.Brand)
                .Include(x => x.Department)
                .Include(x => x.Category)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByCategory(int categoryId)
        {
            return await _context.Products.Where(x => x.CategoryId == categoryId)
               .Include(x => x.Brand)
               .Include(x => x.Department)
               .Include(x => x.Category)
               .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByDepartment(int departmentId)
        {
            return await _context.Products.Where(x => x.DepartmentId == departmentId)
               .Include(x => x.Brand)
               .Include(x => x.Department)
               .Include(x => x.Category)
               .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByName(string name)
        {
            return await _context.Products.Where(x => x.Name == name)
               .Include(x => x.Brand)
               .Include(x => x.Department)
               .Include(x => x.Category)
               .ToListAsync();
        }
    }
}
