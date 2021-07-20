using Microsoft.Extensions.Logging;
using Order.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Infrastructure.Persistence
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
        {            
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetPreconfiguredOrders());
                await orderContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(OrderContext).Name);
            }
        }

        private static IEnumerable<OrderModel> GetPreconfiguredOrders()
        {
            return new List<OrderModel>
            {
                new OrderModel() {UserName = "admin", FirstName = "Teboho", LastName = "Mosakoa", EmailAddress = "mosakoat@gmail.com", AddressLine = "Bahcelievler", Surburb = "Willowbrook", City = "Roodepoort", Province = "Gauteng", ZipCode = "1724", TotalPrice = 350 }
            };
        }
    }
}
