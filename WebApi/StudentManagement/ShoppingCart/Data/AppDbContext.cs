using Microsoft.EntityFrameworkCore;
using ShoppingCart.Models.Entities;

namespace ShoppingCart.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> products { get; set; }
    }
}
