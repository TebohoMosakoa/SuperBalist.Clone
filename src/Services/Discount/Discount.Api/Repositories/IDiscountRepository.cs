﻿using Discount.Api.Models;
using System.Threading.Tasks;

namespace Discount.Api.Repositories
{
    public interface IDiscountRepository
    {
        Task<Coupon> GetDiscount(string userName);

        Task<bool> CreateDiscount(Coupon coupon);
        //Task<bool> UpdateDiscount(Coupon coupon);
        //Task<bool> DeleteDiscount(string productName);
    }
}
