using Microsoft.EntityFrameworkCore;

namespace vega.Models
{
    public class VegaDBContext : DbContext
    {
        public VegaDBContext(DbContextOptions<VegaDBContext> options)
            : base(options)
        {
        }

        public DbSet<Make> Makes { get; set; }
    }
}