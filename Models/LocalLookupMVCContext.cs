using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LocalLookupMVC.Solution.Models
{
    public class LocalLookupMVCContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Business> Businesses { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public LocalLookupMVCContext(DbContextOptions<LocalLookupMVCContext> options) : base(options)
        {
        
        }

    }
}
