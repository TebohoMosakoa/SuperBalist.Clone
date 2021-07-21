using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.Api.Models
{
    public class ShoppingCart
    {
        public string UserName { get; set; }
        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();

        public ShoppingCart()
        {
        }

        public ShoppingCart(string userName)
        {
            UserName = userName;
        }

        private double _total;
        public double TotalPrice
        {
            get
            {
                foreach (var item in Items)
                {
                    _total += item.Price * item.Quantity;
                }
                return _total;
            }
            set 
            {
                if (value > 0)
                    _total = value;
            }
        }
    }
}
