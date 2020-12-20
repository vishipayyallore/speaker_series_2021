using College.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace College.Api.Persistence
{

    public class CollegeDbContext : DbContext
    {

        public CollegeDbContext(DbContextOptions<CollegeDbContext> options) : base(options)
        {

        }

        public DbSet<Professor> Professors { get; set; }

        public DbSet<Student> Students { get; set; }
    }

}
