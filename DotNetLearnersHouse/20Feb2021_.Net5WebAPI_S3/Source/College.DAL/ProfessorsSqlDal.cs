using College.Core.Entities;
using College.Core.Interfaces;
using College.DAL.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace College.DAL
{

    public class ProfessorsSqlDal : IProfessorsSqlDal
    {
        private readonly CollegeSqlDbContext _collegeSqlDbContext;
        private readonly ILogger<ProfessorsSqlDal> _logger;

        public ProfessorsSqlDal(CollegeSqlDbContext collegeSqlDbContext, ILogger<ProfessorsSqlDal> logger)
        {
            _collegeSqlDbContext = collegeSqlDbContext ?? throw new ArgumentNullException(nameof(collegeSqlDbContext));

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<Professor>> GetAllProfessors()
        {
            IEnumerable<Professor> professors;

            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsSqlDal::GetAllProfessors");

            professors = await _collegeSqlDbContext.Professors
                                .Include(student => student.Students)
                                .ToListAsync()
                                .ConfigureAwait(false);

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsSqlDal::GetAllProfessors");

            // To Simulate Exception
            // throw new Exception("Hurray!!!");

            return professors;
        }

        public async Task<Professor> GetProfessorById(Guid professorId)
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsSqlDal::GetProfessorById");

            Professor professor = await _collegeSqlDbContext.Professors
                .Where(record => record.ProfessorId == professorId)
                .Include(student => student.Students)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsSqlDal::GetProfessorById");

            // To Simulate Exception
            // throw new Exception("Hurray!!!");

            return professor;
        }

    }

}
