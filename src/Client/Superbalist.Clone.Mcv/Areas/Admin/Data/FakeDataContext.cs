using Microsoft.EntityFrameworkCore;
using Superbalist.Clone.Mcv.Areas.Admin.Models;

namespace Superbalist.Clone.Mcv.Areas.Admin.Data
{
    public class FakeDataContext : DbContext
    {
        public FakeDataContext(DbContextOptions<FakeDataContext> options) : base(options)
        {

        }

        public DbSet<Test> Tests { get; set; }
    }
}
