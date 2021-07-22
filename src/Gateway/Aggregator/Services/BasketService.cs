using Aggregator.Extensions;
using Aggregator.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Aggregator.Services
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _client;

        public BasketService(HttpClient client)
        {
            _client = client;
        }

        public async Task<BasketModel> GetBasket(string userName)
        {
            var response = await _client.GetAsync($"/api/Basket/{userName}");
            return await response.ReadContentAs<BasketModel>();
        }
    }
}
