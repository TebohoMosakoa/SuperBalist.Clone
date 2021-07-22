using Aggregator.Models;
using Aggregator.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Aggregator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        private readonly IProductService _catalogService;
        private readonly IBasketService _basketService;
        private readonly IOrderService _orderService;

        public ShoppingController(IProductService catalogService, IBasketService basketService, IOrderService orderService)
        {
            _catalogService = catalogService ?? throw new ArgumentNullException(nameof(catalogService));
            _basketService = basketService ?? throw new ArgumentNullException(nameof(basketService));
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        }

        [HttpGet("{userName}", Name = "GetShopping")]
        [ProducesResponseType(typeof(ShoppingModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingModel>> GetShopping(string userName)
        {
            var basket = await _basketService.GetBasket(userName);

            foreach (var item in basket.Items)
            {
                var product = await _catalogService.Get(item.ProductId);

                // set additional product fields
                item.ProductName = product.Name;
                item.Size = product.Size;
                item.Category = product.Category.Name;
                item.Brand = product.Brand.Name;
                item.Department = product.Department.Name;
                item.Description = product.Description;
                item.ImageFile = product.MainImageUrl;
                item.Size = product.Size;
            }

            var orders = await _orderService.GetOrdersByUserName(userName);

            var shoppingModel = new ShoppingModel
            {
                UserName = userName,
                BaskeWithProducts = basket,
                Orders = orders
            };

            return Ok(shoppingModel);
        }

    }
}
