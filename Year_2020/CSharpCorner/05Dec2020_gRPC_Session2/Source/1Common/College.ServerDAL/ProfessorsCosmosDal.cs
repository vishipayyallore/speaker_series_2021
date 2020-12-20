using College.ApplicationCore.Entities;
using College.ApplicationCore.Interfaces;
using College.ServerDAL.Persistence;
using Microsoft.Extensions.Logging;
using System;
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

            await _collegeCosmosDbContext.SaveChangesAsync();

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsCosmosDal::AddProfessor");

            return professor;
        }

    }

}
