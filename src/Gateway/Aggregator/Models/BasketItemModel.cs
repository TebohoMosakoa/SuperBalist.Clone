﻿namespace Aggregator.Models
{
    public class BasketItemModel
    {
        public int Quantity { get; set; }
        public string Color { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public string Department { get; set; }
        public double Price { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }


        public string Size { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
    }
}
