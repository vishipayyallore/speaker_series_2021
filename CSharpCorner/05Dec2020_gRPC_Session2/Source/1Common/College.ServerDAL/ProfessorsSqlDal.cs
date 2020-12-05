using College.ApplicationCore.Entities;
using College.ApplicationCore.Interfaces;
using College.ServerDAL.Persistence;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace College.ServerDAL
{

    public class ProfessorsSqlDal : IProfessorsSqlDal
    {
        private readonly CollegeSqlDbContext _collegeDbContext;
        private readonly ILogger<ProfessorsSqlDal> _logger;

        public ProfessorsSqlDal(CollegeSqlDbContext collegeDbContext, ILogger<ProfessorsSqlDal> logger)
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
