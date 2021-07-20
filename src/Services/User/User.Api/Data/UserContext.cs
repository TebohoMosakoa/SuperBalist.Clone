using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using User.Api.Models;

namespace User.Api.Data
{
    public class UserContext : IdentityDbContext<ApplicationUser>
    {
        public UserContext(DbContextOptions options)
       : base(options)
        {
        }


        public override DbSet<ApplicationUser> Users { get; set; }
    }
}
