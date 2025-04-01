using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Data
{
    public class ITIContextFactory : IDesignTimeDbContextFactory<ITIContext>
    {
        public ITIContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ITIContext>();
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer("Server=.;Database=ITIWithCristenApi;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true");

            return new ITIContext(optionsBuilder.Options);
        }
    }
}
