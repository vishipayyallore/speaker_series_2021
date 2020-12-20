using College.Api.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace College.Api.Persistence
{

    public class ProfessorsDal
    {
        private readonly CollegeDbContext _collegeDbContext;
        private readonly ILogger<ProfessorsDal> _logger;

        public ProfessorsDal(CollegeDbContext collegeDbContext, ILogger<ProfessorsDal> logger)
        {
            _collegeDbContext = collegeDbContext ?? throw new ArgumentNullException(nameof(collegeDbContext));
            
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Professor> AddProfessor(Professor professor)
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsDal::AddProfessor");

            _collegeDbContext.Professors.Add(professor);

            await _collegeDbContext.SaveChangesAsync();

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsDal::AddProfessor");

            return professor;
        }

    }

}
