﻿namespace Discount.Grpc.Models
{
    public class Coupon
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
    }
}
