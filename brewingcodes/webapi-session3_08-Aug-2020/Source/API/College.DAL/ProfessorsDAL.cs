using College.Core.Constants;
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

    public class ProfessorsDAL : IProfessorsDAL
    {
        private readonly CollegeDbContext _collegeDbContext;
        private readonly ILogger<ProfessorsDAL> _logger;
        private readonly ICacheDbDal _cacheDbDal;

        public ProfessorsDAL(CollegeDbContext collegeDbContext, ILogger<ProfessorsDAL> logger
                                , ICacheDbDal cacheDbDal)
        {
            _collegeDbContext = collegeDbContext;

            _logger = logger;

            _cacheDbDal = cacheDbDal;
        }

        public async Task<Professor> AddProfessor(Professor professor)
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorDAL::AddProfessor");

            // Saving into SQL Server
            _collegeDbContext.Professors.Add(professor);

            await _collegeDbContext.SaveChangesAsync();

            // Clear the item from Redis Cache
            await _cacheDbDal.DeleteItemFromCache(Constants.RedisCacheStore.AllProfessorsKey);

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorDAL::AddProfessor");

            return professor;
        }

        public async Task<IEnumerable<Professor>> GetAllProfessors()
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorDAL::GetAllProfessors");

            var professors = await _collegeDbContext.Professors
                .Include(student => student.Students)
                .ToListAsync();

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorDAL::GetAllProfessors");

            return professors;
        }

        public async Task<Professor> GetProfessorById(Guid professorId)
        {
            Professor professor = null;

            _logger.Log(LogLevel.Debug, "Request Received for ProfessorDAL::GetProfessorById");

            professor = await _collegeDbContext.Professors
                .Where(record => record.ProfessorId == professorId)
                .Include(student => student.Students)
                .FirstOrDefaultAsync();

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorDAL::GetProfessorById");

            return professor;
        }

        public async Task<Professor> UpdateProfessor(Professor professor)
        {
            if (!_collegeDbContext.Professors.Any(record => record.ProfessorId == professor.ProfessorId))
            {
                return null;
            }

            var retrievedProfessor = await _collegeDbContext.Professors
                .Where(record => record.ProfessorId == professor.ProfessorId)
                .FirstOrDefaultAsync();

            // Modifying the data
            retrievedProfessor.Salary = professor.Salary;
            retrievedProfessor.IsPhd = professor.IsPhd;

            await _collegeDbContext.SaveChangesAsync();

            return professor;
        }

        public async Task<bool> DeleteProfessorById(Guid id)
        {
            if (!_collegeDbContext.Professors.Any(record => record.ProfessorId == id))
            {
                return false;
            }

            var retrievedProfessor = await _collegeDbContext.Professors
                .Where(record => record.ProfessorId == id)
                .FirstOrDefaultAsync();

            _collegeDbContext.Professors.Remove(retrievedProfessor);

            await _collegeDbContext.SaveChangesAsync();

            return true;
        }

    }

}
