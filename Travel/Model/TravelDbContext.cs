using Microsoft.EntityFrameworkCore;

namespace TravelService.Model
{
    public class TravelDbContext : DbContext
    {
        public TravelDbContext()
        {

        }

        public TravelDbContext(DbContextOptions<TravelDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Data Source=.;Initial Catalog=Travel;Integrated Security=True;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Travel> Travels { get; set; }
        public DbSet<Traveler> Travelers { get; set; }
    }
}
