using Order.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Order.Application.Contracts.Persistence
{
    public interface IOrderRepository : IAsyncRepository<OrderModel>
    {
        Task<IEnumerable<OrderModel>> GetOrdersByUserName(string userName);
    }
}
