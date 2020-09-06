using College.WebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace College.WebAPI.DAL.Persistence
{
    public class CollegeCosmosDbContext : DbContext
    {
        public CollegeCosmosDbContext(DbContextOptions<CollegeCosmosDbContext> options)
            : base(options)
        {
        }

        public DbSet<Professor> Professors { get; set; }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region DefaultContainer
            modelBuilder.HasDefaultContainer("College");
            #endregion

            #region Container
            modelBuilder.Entity<Professor>()
                .ToContainer("Professors");
            #endregion

            #region PartitionKey
            //modelBuilder.Entity<Professor>()
            //    .HasPartitionKey(o => o.ProfessorId.ToString());
            #endregion
        }
    }
}
