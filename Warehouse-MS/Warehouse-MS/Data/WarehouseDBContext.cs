using Microsoft.EntityFrameworkCore;
namespace Warehouse_MS.Data
{
    public class WarehouseDBContext : DbContext
    {
        public WarehouseDBContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // This calls the base method, but does nothing
            base.OnModelCreating(modelBuilder);
        }
    }
}
