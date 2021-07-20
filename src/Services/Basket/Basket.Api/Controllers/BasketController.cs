using Basket.Api.Models;
using Basket.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Basket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _repository;
        //private readonly DiscountGrpcService _discountGrpcService;
        //private readonly IPublishEndpoint _publishEndpoint;
        //private readonly IMapper _mapper;

        public BasketController(IBasketRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            //_discountGrpcService = discountGrpcService ?? throw new ArgumentNullException(nameof(discountGrpcService));
            //_publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
            //_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("{userName}", Name = "GetBasket")]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> GetBasket(string userName)
        {
            var basket = await _repository.GetBasket(userName);
            return Ok(basket ?? new ShoppingCart(userName));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> UpdateBasket([FromBody] ShoppingCart basket)
        {
            // Communicate with Discount.Grpc and calculate lastest prices of products into sc
            //foreach (var item in basket.Items)
            //{
            //    var coupon = await _discountGrpcService.GetDiscount(item.ProductName);
            //    item.Price -= coupon.Amount;
            //}

            return Ok(await _repository.UpdateBasket(basket));
        }

        [HttpDelete("{userName}", Name = "DeleteBasket")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBasket(string userName)
        {
            await _repository.DeleteBasket(userName);
            return Ok();
        }
    }
}
