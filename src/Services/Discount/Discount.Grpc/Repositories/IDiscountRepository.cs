﻿using Discount.Grpc.Models;
using System.Threading.Tasks;

namespace Discount.Grpc.Repositories
{
    public interface IDiscountRepository
    {
        Task<Coupon> GetDiscount(string userName);

        Task<bool> CreateDiscount(Coupon coupon);
        //Task<bool> UpdateDiscount(Coupon coupon);
        //Task<bool> DeleteDiscount(string productName);
    }
}
