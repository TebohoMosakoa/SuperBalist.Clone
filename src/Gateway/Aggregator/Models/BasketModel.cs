using System.Collections.Generic;

namespace Aggregator.Models
{
    public class BasketModel
    {
        public string UserName { get; set; }
        public List<BasketItemModel> Items { get; set; } = new List<BasketItemModel>();
        public double TotalPrice { get; set; }
    }
}
