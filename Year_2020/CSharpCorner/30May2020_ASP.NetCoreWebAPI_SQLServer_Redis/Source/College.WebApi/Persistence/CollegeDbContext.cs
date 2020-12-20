using College.WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace College.WebApi.Persistence
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
