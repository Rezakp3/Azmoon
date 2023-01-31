using Microsoft.EntityFrameworkCore;

namespace DriverService.Model
{
    public class DriverDbContext : DbContext
    {
        public DriverDbContext()
        {

        }
        public DriverDbContext(DbContextOptions op)
            : base(op) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Data Source=.;Initial Catalog=Driver;Integrated Security=True;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var driver = modelBuilder.Entity<Driver>();
            driver.HasKey(x => x.Id);
            driver.Property(x => x.Name).HasMaxLength(20);
            driver.Property(x => x.Family).HasMaxLength(30);
            driver.Property(x => x.Number).HasMaxLength(13);
            driver.Property(x => x.NationalCode).HasMaxLength(11);
            driver.Property(x => x.CarBrand).HasMaxLength(20);
            driver.Property(x => x.CarModel).HasMaxLength(20);
            driver.Property(x => x.CarTag).HasMaxLength(20);
        }

        public DbSet<Driver> Drivers { get; set; }
    }
}
