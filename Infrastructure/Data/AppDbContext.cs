using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base (options)
        {
        }

        DbSet<Product> Product { get; set; }
        DbSet<ProductCategory> ProductCategory { get; set; }

    }
}
