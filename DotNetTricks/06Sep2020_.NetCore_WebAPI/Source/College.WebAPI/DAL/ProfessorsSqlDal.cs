using College.WebAPI.DAL.Persistence;
using College.WebAPI.Entities;
using College.WebAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace College.WebAPI.DAL
{

    public class ProfessorsSqlDal : IProfessorsSqlDal
    {
        private readonly CollegeSqlDbContext _collegeSqlDbContext;
        private readonly ILogger<ProfessorsSqlDal> _logger;

        public ProfessorsSqlDal(CollegeSqlDbContext collegeSqlDbContext, ILogger<ProfessorsSqlDal> logger)
        {
            _collegeSqlDbContext = collegeSqlDbContext;

            _logger = logger;
        }

        public async Task<Professor> AddProfessor(Professor professor)
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsSqlDal::AddProfessor");

            // Saving into SQL Server
            _collegeSqlDbContext.Professors.Add(professor);

            await _collegeSqlDbContext.SaveChangesAsync();

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsSqlDal::AddProfessor");

            return professor;
        }

        public async Task<IEnumerable<Professor>> GetAllProfessors()
        {
            IEnumerable<Professor> professors;

            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsSqlDal::GetAllProfessors");

                // Retrieve the data from SQL Server
                professors = await _collegeSqlDbContext.Professors
                    .Include(student => student.Students)
                    .ToListAsync();
            
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
                    .FirstOrDefaultAsync();

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsSqlDal::GetProfessorById");

            return professor;
        }

        public async Task<Professor> UpdateProfessor(Professor professor)
        {
            if (!_collegeSqlDbContext.Professors.Any(record => record.ProfessorId == professor.ProfessorId))
            {
                return null;
            }

            var retrievedProfessor = await _collegeSqlDbContext.Professors
                .Where(record => record.ProfessorId == professor.ProfessorId)
                .FirstOrDefaultAsync();

            // Modifying the data
            retrievedProfessor.Name = professor.Name;
            retrievedProfessor.Salary = professor.Salary;
            retrievedProfessor.Teaches = professor.Teaches;
            retrievedProfessor.IsPhd = professor.IsPhd;

            await _collegeSqlDbContext.SaveChangesAsync();

            return professor;
        }

        public async Task<bool> DeleteProfessorById(Guid id)
        {
            if (!_collegeSqlDbContext.Professors.Any(record => record.ProfessorId == id))
            {
                return false;
            }

            var retrievedProfessor = await _collegeSqlDbContext.Professors
                .Where(record => record.ProfessorId == id)
                .FirstOrDefaultAsync();

            _collegeSqlDbContext.Professors.Remove(retrievedProfessor);

            await _collegeSqlDbContext.SaveChangesAsync();

            return true;
        }


    }

}
