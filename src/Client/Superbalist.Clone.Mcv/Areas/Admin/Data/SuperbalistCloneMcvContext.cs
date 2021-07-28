using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Superbalist.Clone.Mcv.Areas.Admin.Models;

namespace Superbalist.Clone.Mcv.Data
{
    public class SuperbalistCloneMcvContext : DbContext
    {
        public SuperbalistCloneMcvContext (DbContextOptions<SuperbalistCloneMcvContext> options)
            : base(options)
        {
        }

        public DbSet<Superbalist.Clone.Mcv.Areas.Admin.Models.Test> Test { get; set; }
    }
}
