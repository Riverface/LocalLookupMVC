using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace LocalLookupMVC.Models
{
    public class LocalLookupMVCContextFactory : IDesignTimeDbContextFactory<LocalLookupMVCContext>
    {
        LocalLookupMVCContext IDesignTimeDbContextFactory<LocalLookupMVCContext>.CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();

            var builder = new DbContextOptionsBuilder<LocalLookupMVCContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseMySql(connectionString);

            return new LocalLookupMVCContext(builder.Options);
        }
    }
}