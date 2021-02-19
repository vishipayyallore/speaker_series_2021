using College.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace College.DAL.Persistence
{

    public class CollegeSqlDbContext : DbContext
    {
        public CollegeSqlDbContext(DbContextOptions<CollegeSqlDbContext> options) : base(options)
        {
        }

        public DbSet<Professor> Professors { get; set; }

        public DbSet<Student> Students { get; set; }
    }

}
