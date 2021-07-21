using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Promotion.GRPC.Data;
using Promotion.GRPC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promotion.GRPC.Repositories
{
    public class PromotionRepository : IPromotionRepository
    {
        private readonly PromotionContext _context;
        public PromotionRepository(PromotionContext context)
        {
            _context = context;
        }

        public Promo GetPromo(int id)
        {
            foreach (var promo in _context.Promotions)
            {
                foreach (var item in promo.Items)
                {
                    if (item.ProductId == id)
                        return promo;
                }

            }
            return null;

        }
    }
}
