using Microsoft.EntityFrameworkCore;
using Promotion.GRPC.Models;

namespace Promotion.GRPC.Data
{
    public class PromotionContext : DbContext
    {
        public PromotionContext(DbContextOptions<PromotionContext> options) : base(options)
        {

        }
        public DbSet<Item> Items { get; set; }
        public DbSet<Promo> Promotions { get; set; }
    }
}
