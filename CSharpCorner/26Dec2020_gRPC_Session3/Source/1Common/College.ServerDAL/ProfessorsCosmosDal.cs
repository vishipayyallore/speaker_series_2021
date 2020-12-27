using College.ApplicationCore.Entities;
using College.ApplicationCore.Interfaces;
using College.ServerDAL.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace College.ServerDAL
{
    public class ProfessorsCosmosDal : IProfessorsCosmosDal
    {
        private readonly CollegeCosmosDbContext _collegeCosmosDbContext;
        private readonly ILogger<ProfessorsCosmosDal> _logger;

        public ProfessorsCosmosDal(CollegeCosmosDbContext collegeCosmosDbContext,
            ILogger<ProfessorsCosmosDal> logger)
        {
            _collegeCosmosDbContext = collegeCosmosDbContext ?? throw new ArgumentNullException(nameof(collegeCosmosDbContext));

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Professor> AddProfessor(Professor professor)
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsCosmosDal::AddProfessor");

            _collegeCosmosDbContext.Professors.Add(professor);

            await _collegeCosmosDbContext.SaveChangesAsync()
                                            .ConfigureAwait(false);

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsCosmosDal::AddProfessor");

            return professor;
        }

        public async Task<Professor> GetProfessorById(Guid professorId)
        {
            Professor professor = null;

            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsCosmosDal::GetProfessorById");

            professor = await _collegeCosmosDbContext.Professors
                                .Where(record => record.ProfessorId == professorId)
                                .FirstOrDefaultAsync()
                                .ConfigureAwait(false);

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsCosmosDal::GetProfessorById");

            return professor;
        }

        public async Task<IEnumerable<Professor>> GetAllProfessors()
        {
            IEnumerable<Professor> professors;

            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsCosmosDal::GetAllProfessors");

            professors = await _collegeCosmosDbContext.Professors
                                    .ToListAsync()
                                    .ConfigureAwait(false);

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsCosmosDal::GetAllProfessors");

            return professors;
        }

        public async Task<Professor> UpdateProfessor(Professor professor)
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsCosmosDal::UpdateProfessor");

            var retrievedProfessor = await _collegeCosmosDbContext.Professors
                .Where(record => record.ProfessorId == professor.ProfessorId)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

            if (retrievedProfessor == null)
            {
                return null;
            }

            retrievedProfessor.Name = professor.Name;
            retrievedProfessor.Salary = professor.Salary;
            retrievedProfessor.Teaches = professor.Teaches;
            retrievedProfessor.IsPhd = professor.IsPhd;

            await _collegeCosmosDbContext.SaveChangesAsync()
                                        .ConfigureAwait(false);
            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsCosmosDal::UpdateProfessor");

            return professor;
        }

        public async Task<bool> DeleteProfessorById(Guid professorId)
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsCosmosDal::DeleteProfessorById");

            var retrievedProfessor = await _collegeCosmosDbContext.Professors
                .Where(record => record.ProfessorId == professorId)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

            if (retrievedProfessor == null)
            {
                return false;
            }

            _collegeCosmosDbContext.Professors.Remove(retrievedProfessor);

            await _collegeCosmosDbContext.SaveChangesAsync()
                                        .ConfigureAwait(false);

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsCosmosDal::DeleteProfessorById");

            return true;
        }

    }

}
