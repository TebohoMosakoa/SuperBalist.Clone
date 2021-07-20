using Catalog.Api.Models;
using Catalog.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseController<Category, CategoryRepository>
    {
        public CategoriesController(CategoryRepository repository) : base(repository)
        {

        }
    }
}
