using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Promotion.Api.Models;
using Promotion.Api.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Promotion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionsController : ControllerBase
    {
        private readonly IPromotionRepository _repository;

        public PromotionsController(IPromotionRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Promo>>> Get()
        {
            return await _repository.GetPromos();
        }

        // GET: api/[controller]/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Promo>> Get(int id)
        {
            var promo = await _repository.GetPromo(id);
            if (promo == null)
            {
                return NotFound();
            }
            return promo;
        }

        // PUT: api/[controller]/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Promo promo)
        {
            if (id != promo.Id)
            {
                return BadRequest();
            }
            await _repository.UpdatePromo(promo);
            return NoContent();
        }

        // POST: api/[controller]
        [HttpPost]
        public async Task<ActionResult<Promo>> Post(Promo promo)
        {
            await _repository.CreatePromo(promo);
            return CreatedAtAction("Get", new { id = promo.Id }, promo);
        }

        // DELETE: api/[controller]/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var promo = await _repository.GetPromo(id);
            //var promo = await _repository.DeletePromo(id);
            if (promo == null)
            {
                return NotFound();
            }
            try
            {
                var result = await _repository.DeletePromo(id);
                return NoContent();
            }
            catch (System.Exception)
            {

                throw;
            }
            
        }
    }
}
