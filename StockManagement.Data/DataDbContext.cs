using Microsoft.EntityFrameworkCore;
using StockManagement.Domain.Entities;
using System.Reflection;

namespace StockManagement.Data
{
    public class DataDbContext(DbContextOptions<DataDbContext> options) : DbContext(options)
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
