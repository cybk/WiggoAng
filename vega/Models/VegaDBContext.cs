using Microsoft.EntityFrameworkCore;

namespace vega.Models
{
    public class VegaDBContext : DbContext
    {

        public DbSet<Make> Makes { get; set; }

        public DbSet<Feature> Features { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        public VegaDBContext(DbContextOptions<VegaDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleFeature>().HasKey( vf => new { vf.VehicleId, vf.FeatureId });
        }

    }
}