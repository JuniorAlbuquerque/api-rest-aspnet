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

        public DbSet<Product> products { get; set; }

        public DbSet<Category> categories { get; set; }
    }
}
