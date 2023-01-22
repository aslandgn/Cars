using Cars.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Version = Cars.Entity.Entities.Version;

namespace Cars.Dal
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options): base(options) { }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Spesification> Spesifications { get; set; }
        public DbSet<TransmissionType> TransmissionTypes { get; set; }
        public DbSet<Version> Versions { get; set; }
        public DbSet<VersionSpesification> VersionSpesifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarContext).Assembly);
        }
    }
}