using System;
using System.Collections.Generic;
using System.Text;

namespace EventBus.Messages.Events
{
    public class AddItemToPromotionEvent
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string ProductImage { get; set; }

    }
}
