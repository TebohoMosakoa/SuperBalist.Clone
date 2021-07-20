using Microsoft.EntityFrameworkCore;
using Order.Domain.Common;
using Order.Domain.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Order.Infrastructure.Persistence
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
        }

        public DbSet<OrderModel> Orders { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.DateCreated = DateTime.Now;
                        entry.Entity.CreatedBy = "admin";
                        break;
                    case EntityState.Modified:
                        entry.Entity.DateModified = DateTime.Now;
                        entry.Entity.ModifiedBy = "admin";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
