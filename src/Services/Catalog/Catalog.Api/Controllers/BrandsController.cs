using Catalog.Api.Models;
using Catalog.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController<Brand, BrandRepository>
    {
        public BrandsController(BrandRepository repository) : base(repository)
        {

        }
    }
}
