using Aggregator.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aggregator.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetAll();
        Task<ProductModel> Get(int id);
        Task<IEnumerable<ProductModel>> GetByName(string name);
        Task<IEnumerable<ProductModel>> GetByBrand(int brandId);
        Task<IEnumerable<ProductModel>> GetByCategory(int categoryId);
        Task<IEnumerable<ProductModel>> GetByDepartment(int departmentId);
    }
}
