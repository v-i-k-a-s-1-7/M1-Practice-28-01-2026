using Microsoft.EntityFrameworkCore;
using StudentMarks.Models.Entities;

namespace StudentMarks.Data
{
    public class MarksDbContext  : DbContext
    {
        public MarksDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<SubjectMarks> SubjectMarks { get; set; }
    }
}
