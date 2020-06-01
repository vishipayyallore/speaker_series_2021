using College.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace College.ServerDAL.Persistence
{

    public class CollegeDbContext : DbContext
    {

        public CollegeDbContext(DbContextOptions<CollegeDbContext> options) : base(options)
        {

        }

        public DbSet<Professor> Professors { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Address> AddressBook { get; set; }
    }

}
