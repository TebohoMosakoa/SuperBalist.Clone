
using Discount.Api.Models;
using Discount.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Discount.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountRepository _repository;

        public DiscountController(IDiscountRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("{userName}", Name = "GetDiscount")]
        [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Coupon>> GetDiscount(string userName)
        {
            var discount = await _repository.GetDiscount(userName);
            return Ok(discount);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Coupon>> CreateDiscount([FromBody] Coupon coupon)
        {
            await _repository.CreateDiscount(coupon);
            return CreatedAtRoute("GetDiscount", new { productName = coupon.UserName }, coupon);
        }


        //[HttpDelete("{productName}", Name = "DeleteDiscount")]
        //[ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        //public async Task<ActionResult<bool>> DeleteDiscount(string productName)
        //{
        //    return Ok(await _repository.DeleteDiscount(productName));
        //}
    }
}
