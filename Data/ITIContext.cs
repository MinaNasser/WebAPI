using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data
{

    public class ITIContext : IdentityDbContext<AppUser>
    {
        //public ITIContext()
        //{
        //}

        public ITIContext(DbContextOptions<ITIContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer("Server=.;Database=ITIWithCristen;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true");
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //// ����� ������� ������� �� IdentityUserLogin<string>
            //modelBuilder.Entity<IdentityUserLogin<string>>()
            //    .HasKey(l => new { l.LoginProvider, l.ProviderKey });

            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        }
    }

}