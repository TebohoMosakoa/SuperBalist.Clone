using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.Api.Models
{
    public class ShoppingCartItem
    {
        public int Quantity { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
