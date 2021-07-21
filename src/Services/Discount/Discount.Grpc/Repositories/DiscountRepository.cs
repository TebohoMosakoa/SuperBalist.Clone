﻿using Dapper;
using Discount.Grpc.Models;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Threading.Tasks;

namespace Discount.Grpc.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly IConfiguration _configuration;

        public DiscountRepository(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<Coupon> GetDiscount(string userName)
        {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>
                ("SELECT * FROM Coupon WHERE UserName = @UserName", new { UserName = userName });

            return coupon;
        }

        public async Task<bool> CreateDiscount(Coupon coupon)
        {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var affected =
                await connection.ExecuteAsync
                    ("INSERT INTO Coupon (UserName, Description, Amount) VALUES (@name, First Purchase, @amount)",
                            new { name = coupon.UserName, amount = coupon.Amount });

            if (affected == 0)
                return false;

            return true;
        }

        //public async Task<bool> UpdateDiscount(Coupon coupon)
        //{
        //    using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

        //    var affected = await connection.ExecuteAsync
        //            ("UPDATE Coupon SET ProductName=@ProductName, Description = @Description, Amount = @Amount WHERE Id = @Id",
        //                    new { coupon.ProductName, coupon.Description, coupon.Amount, coupon.Id });

        //    if (affected == 0)
        //        return false;

        //    return true;
        //}

        //public async Task<bool> DeleteDiscount(string productName)
        //{
        //    using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

        //    var affected = await connection.ExecuteAsync("DELETE FROM Coupon WHERE ProductName = @ProductName",
        //        new { ProductName = productName });

        //    if (affected == 0)
        //        return false;

        //    return true;
        //}
    }
}