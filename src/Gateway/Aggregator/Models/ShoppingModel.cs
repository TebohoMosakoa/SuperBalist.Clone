using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aggregator.Models
{
    public class ShoppingModel
    {
        public string UserName { get; set; }
        public BasketModel BaskeWithProducts { get; set; }
        public IEnumerable<OrderResponseModel> Orders { get; set; }
    }
}
