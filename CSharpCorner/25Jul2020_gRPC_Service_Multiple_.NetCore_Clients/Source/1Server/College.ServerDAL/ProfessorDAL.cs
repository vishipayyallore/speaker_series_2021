using College.ApplicationCore.Entities;
using College.ApplicationCore.Interfaces;
using College.ServerDAL.Persistence;
using Microsoft.Extensions.Logging;

namespace College.ServerDAL
{

    public class ProfessorDAL : IProfessorDAL
    {
        private readonly CollegeDbContext _collegeDbContext;
        private readonly ILogger<ProfessorDAL> _logger;

        public ProfessorDAL(CollegeDbContext collegeDbContext, ILogger<ProfessorDAL> logger)
        {
            _collegeDbContext = collegeDbContext;

            _logger = logger;
        }

        public Professor AddProfessor(Professor professor)
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorDAL::AddProfessor");

            _collegeDbContext.Professors.Add(professor);

            _collegeDbContext.SaveChanges();

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorDAL::AddProfessor");

            return professor;
        }

    }

}
