using Microsoft.EntityFrameworkCore;
using Practice_2.Models;

namespace FunctionDemo
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProductCategories>().HasKey(e => new { e.ProductId, e.CategoryId });
        }

        public DbSet<Product> Products { get; set; }
    }
}
