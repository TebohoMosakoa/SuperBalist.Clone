using Aggregator.Extensions;
using Aggregator.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Aggregator.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _client;

        public OrderService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<OrderResponseModel>> GetOrdersByUserName(string userName)
        {
            var response = await _client.GetAsync($"/api/Orders/{userName}");
            return await response.ReadContentAs<List<OrderResponseModel>>();
        }
    }
}
