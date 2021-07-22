using Aggregator.Extensions;
using Aggregator.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Aggregator.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;

        public ProductService(HttpClient client)
        {
            _client = client;
        }

        public async Task<ProductModel> Get(int id)
        {
            var response = await _client.GetAsync($"/api/Products/{id}");
            return await response.ReadContentAs<ProductModel>();
        }

        public async Task<IEnumerable<ProductModel>> GetAll()
        {
            var response = await _client.GetAsync("/api/Products");
            return await response.ReadContentAs<List<ProductModel>>();
        }

        public async Task<IEnumerable<ProductModel>> GetByBrand(int brandId)
        {
            var response = await _client.GetAsync($"/api/Products/GetByBrandId/{brandId}");
            return await response.ReadContentAs<List<ProductModel>>();
        }

        public async Task<IEnumerable<ProductModel>> GetByCategory(int categoryId)
        {
            var response = await _client.GetAsync($"/api/Products/GetByCategoryId/{categoryId}");
            return await response.ReadContentAs<List<ProductModel>>();
        }

        public async Task<IEnumerable<ProductModel>> GetByDepartment(int departmentId)
        {
            var response = await _client.GetAsync($"/api/Products/GetByDepartmentId/{departmentId}");
            return await response.ReadContentAs<List<ProductModel>>();
        }

        public async Task<IEnumerable<ProductModel>> GetByName(string name)
        {
            var response = await _client.GetAsync($"/api/Products/GetByName/{name}");
            return await response.ReadContentAs<List<ProductModel>>();
        }
    }
}
