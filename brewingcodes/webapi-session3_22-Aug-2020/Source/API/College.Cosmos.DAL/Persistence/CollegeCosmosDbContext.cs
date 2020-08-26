using College.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace College.Cosmos.DAL.Persistence
{
    public class CollegeCosmosDbContext : DbContext
    {
        public CollegeCosmosDbContext(DbContextOptions<CollegeCosmosDbContext> options)
            : base(options)
        {
        }

        public DbSet<Professor> Professors { get; set; }

        public DbSet<Student> Students { get; set; }

        #region Configuration
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseCosmos(
        //            "https://localhost:8081",
        //            "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==",
        //            databaseName: "College")
        //    .EnableSensitiveDataLogging(true);
        #endregion

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
