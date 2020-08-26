using College.Core.Entities;
using College.Core.Interfaces;
using College.CosmosDb.DAL.Persistence;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace College.CosmosDb.DAL
{
    public class ProfessorsCosmosDal : IProfessorsCosmosDal
    {
        private readonly CollegeCosmosDbContext _collegeCosmosDbContext;
        private readonly ILogger<ProfessorsCosmosDal> _logger;
        private readonly IRedisCacheDbDal _cacheDbDal;

        public ProfessorsCosmosDal(CollegeCosmosDbContext collegeCosmosDbContext, 
            ILogger<ProfessorsCosmosDal> logger, IRedisCacheDbDal cacheDbDal)
        {
            _collegeCosmosDbContext = collegeCosmosDbContext;
            _logger = logger;
            _cacheDbDal = cacheDbDal;
        }

        public async Task<Professor> AddProfessor(Professor professor)
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorDAL::AddProfessor");

            // Saving into Cosmos Db
            _collegeCosmosDbContext.Professors.Add(professor);

            await _collegeCosmosDbContext.SaveChangesAsync();

            // await RemoveAllProfessorsFromCache();

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorDAL::AddProfessor");

            return professor;
        }

        public Task<bool> DeleteProfessorById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Professor>> GetAllProfessors()
        {
            throw new NotImplementedException();
        }

        public Task<Professor> GetProfessorById(Guid professorId)
        {
            throw new NotImplementedException();
        }

        public Task<Professor> UpdateProfessor(Professor professor)
        {
            throw new NotImplementedException();
        }
    }
}
