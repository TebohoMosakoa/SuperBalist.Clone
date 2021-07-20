using Catalog.Api.Models;
using Catalog.Api.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Api.Repositories
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        Task<IEnumerable<Product>> GetByName(string name);
        Task<IEnumerable<Product>> GetByBrand(int brandId);
        Task<IEnumerable<Product>> GetByCategory(int categoryId);
        Task<IEnumerable<Product>> GetByDepartment(int departmentId);
    }
}
