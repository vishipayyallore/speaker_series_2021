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
    public class ProfessorsCosmosDal : IProfessorsCosmosDal
    {
        private readonly CollegeCosmosDbContext _collegeCosmosDbContext;
        private readonly ILogger<ProfessorsCosmosDal> _logger;

        public ProfessorsCosmosDal(CollegeCosmosDbContext collegeCosmosDbContext,
            ILogger<ProfessorsCosmosDal> logger)
        {
            _collegeCosmosDbContext = collegeCosmosDbContext;

            _logger = logger;
        }

        public async Task<Professor> AddProfessor(Professor professor)
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsCosmosDal::AddProfessor");

            _collegeCosmosDbContext.Professors.Add(professor);

            await _collegeCosmosDbContext.SaveChangesAsync();

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsCosmosDal::AddProfessor");

            return professor;
        }

        public async Task<IEnumerable<Professor>> GetAllProfessors()
        {
            IEnumerable<Professor> professors;

            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsCosmosDal::GetAllProfessors");

            professors = await _collegeCosmosDbContext.Professors.ToListAsync();

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsCosmosDal::GetAllProfessors");

            return professors;
        }

        public async Task<Professor> GetProfessorById(Guid professorId)
        {
            Professor professor = null;

            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsCosmosDal::GetProfessorById");


            professor = await _collegeCosmosDbContext.Professors
                                .Where(record => record.ProfessorId == professorId)
                                .FirstOrDefaultAsync();

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsCosmosDal::GetProfessorById");

            return professor;
        }

        public async Task<Professor> UpdateProfessor(Professor professor)
        {
            var retrievedProfessor = await _collegeCosmosDbContext.Professors
                                                .Where(record => record.ProfessorId == professor.ProfessorId)
                                                .FirstOrDefaultAsync();

            if (retrievedProfessor == null)
            {
                return null;
            }

            // Modifying the data
            retrievedProfessor.Name = professor.Name;
            retrievedProfessor.Salary = professor.Salary;
            retrievedProfessor.Teaches = professor.Teaches;
            retrievedProfessor.IsPhd = professor.IsPhd;

            await _collegeCosmosDbContext.SaveChangesAsync();

            return professor;
        }

        public async Task<bool?> DeleteProfessorById(Guid id)
        {
            var retrievedProfessor = await _collegeCosmosDbContext.Professors
                                                .Where(record => record.ProfessorId == id)
                                                .FirstOrDefaultAsync();
            if (retrievedProfessor == null)
            {
                return null;
            }

            _collegeCosmosDbContext.Professors.Remove(retrievedProfessor);

            await _collegeCosmosDbContext.SaveChangesAsync();

            return true;
        }

    }

}
