using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LocalLookupMVC.Models
{
    public class LocalLookupMVCContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Business> Businesses { get; set; }
        public DbSet<City> Cities { get; set; }
        public LocalLookupMVCContext(DbContextOptions<LocalLookupMVCContext> options) : base(options)
        {
        
        }

    }
}
