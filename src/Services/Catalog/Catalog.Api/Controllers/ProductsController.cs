using Catalog.Api.Models;
using Catalog.Api.Repositories;
using Catalog.Api.Repositories.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Catalog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController<Product, ProductRepository>
    {
        private readonly ProductRepository _repository;
        private readonly ILogger<ProductsController> _logger;
        public ProductsController(ProductRepository repository, ILogger<ProductsController> logger, ICloudStorage cloudStorage) : base(repository, cloudStorage)
        {
            _repository = repository;
            _logger = logger;

        }

        [Route("[action]/{name}", Name = "GetByName")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetByName(string name)
        {
            var items = await _repository.GetByName(name);
            if (items == null)
            {
                _logger.LogError($"Products with the name: {name} not found.");
                return NotFound();
            }
            return Ok(items);
        }

        [Route("[action]/{id}", Name = "GetByBrandId")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetByBrandId(int id)
        {
            var items = await _repository.GetByBrand(id);
            if (items == null)
            {
                _logger.LogError($"Products with the Brand id: {id} not found.");
                return NotFound();
            }
            return Ok(items);
        }

        [Route("[action]/{id}", Name = "GetByDepartmentId")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetByDepartmentId(int id)
        {
            var items = await _repository.GetByDepartment(id);
            if (items == null)
            {
                _logger.LogError($"Products with the Department id: {id} not found.");
                return NotFound();
            }
            return Ok(items);
        }

        [Route("[action]/{id}", Name = "GetByCategoryId")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetByCategoryId(int id)
        {
            var items = await _repository.GetByCategory(id);
            if (items == null)
            {
                _logger.LogError($"Products with the Category id: {id} not found.");
                return NotFound();
            }
            return Ok(items);
        }
    }
}
