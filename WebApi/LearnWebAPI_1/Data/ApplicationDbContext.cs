using LearnWebAPI_1.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearnWebAPI_1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
