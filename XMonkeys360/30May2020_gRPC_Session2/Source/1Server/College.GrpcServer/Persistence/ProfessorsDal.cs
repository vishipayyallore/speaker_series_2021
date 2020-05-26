using College.ApplicationCore.Entities;

namespace College.Api.Persistence
{

    public class ProfessorsDal
    {
        private readonly CollegeDbContext _collegeDbContext;

        public ProfessorsDal(CollegeDbContext collegeDbContext)
        {
            _collegeDbContext = collegeDbContext;
        }

        public Professor AddProfessor(Professor professor)
        {
            _collegeDbContext.Professors.Add(professor);

            _collegeDbContext.SaveChanges();

            return professor;
        }

    }

}
