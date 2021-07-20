using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promotion.Api.Models
{
    public class Item
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }

        public string ProductImage { get; set; }
    }
}
