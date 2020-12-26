using College.WebAPI.Core.Entities;
using College.WebAPI.DAL.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace College.WebAPI.DAL
{

    public class ProfessorsSqlDal
    {
        private readonly CollegeSqlDbContext _collegeSqlDbContext;
        private readonly ILogger<ProfessorsSqlDal> _logger;

        public ProfessorsSqlDal(CollegeSqlDbContext collegeSqlDbContext, ILogger<ProfessorsSqlDal> logger)
        {
            _collegeSqlDbContext = collegeSqlDbContext ?? throw new ArgumentNullException(nameof(collegeSqlDbContext));

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Professor> AddProfessor(Professor professor)
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsSqlDal::AddProfessor");

            _collegeSqlDbContext.Professors.Add(professor);

            await _collegeSqlDbContext.SaveChangesAsync()
                    .ConfigureAwait(false);

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsSqlDal::AddProfessor");

            return professor;
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

            return professors;
        }

        public async Task<Professor> GetProfessorById(Guid professorId)
        {
            Professor professor = null;

            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsSqlDal::GetProfessorById");

            professor = await _collegeSqlDbContext.Professors
                                .Where(record => record.ProfessorId == professorId)
                                .Include(student => student.Students)
                                .FirstOrDefaultAsync()
                                .ConfigureAwait(false);

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsSqlDal::GetProfessorById");

            return professor;
        }

        public async Task<Professor> UpdateProfessor(Professor professor)
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsSqlDal::UpdateProfessor");

            if (!_collegeSqlDbContext.Professors.Any(record => record.ProfessorId == professor.ProfessorId))
            {
                return null;
            }

            var retrievedProfessor = await _collegeSqlDbContext.Professors
                                            .Where(record => record.ProfessorId == professor.ProfessorId)
                                            .FirstOrDefaultAsync()
                                            .ConfigureAwait(false);

            retrievedProfessor.Name = professor.Name;
            retrievedProfessor.Salary = professor.Salary;
            retrievedProfessor.Teaches = professor.Teaches;
            retrievedProfessor.IsPhd = professor.IsPhd;

            await _collegeSqlDbContext.SaveChangesAsync()
                    .ConfigureAwait(false);

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsSqlDal::UpdateProfessor");

            return professor;
        }

        public async Task<bool> DeleteProfessorById(Guid professorId)
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsSqlDal::DeleteProfessorById");

            if (!_collegeSqlDbContext.Professors.Any(record => record.ProfessorId == professorId))
            {
                return false;
            }

            var retrievedProfessor = await _collegeSqlDbContext.Professors
                                            .Where(record => record.ProfessorId == professorId)
                                            .FirstOrDefaultAsync()
                                            .ConfigureAwait(false);

            _collegeSqlDbContext.Professors.Remove(retrievedProfessor);

            await _collegeSqlDbContext.SaveChangesAsync()
                    .ConfigureAwait(false);

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsSqlDal::DeleteProfessorById");

            return true;
        }

    }

}
