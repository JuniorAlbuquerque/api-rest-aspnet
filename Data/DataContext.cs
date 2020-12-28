using Microsoft.EntityFrameworkCore;
using testeef.Models;

namespace testeef.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<CategoryProduct>()
                .HasKey(sc => new { sc.categoryid, sc.productid });
        }

        public DbSet<Product> products { get; set; }

        public DbSet<Category> categories { get; set; }

        public DbSet<CategoryProduct> categoryProducts { get; set; }
    }
}
