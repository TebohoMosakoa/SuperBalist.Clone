using Microsoft.EntityFrameworkCore;
using Promotion.Api.Models;

namespace Promotion.Api.Data
{
    public class PromotionContext : DbContext
    {
        public PromotionContext(DbContextOptions<PromotionContext> options) : base(options)
        {

        }

        public DbSet<Promo> Promotions { get; set; }
    }
}
