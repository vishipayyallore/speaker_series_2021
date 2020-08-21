using College.Core.Constants;
using College.Core.Entities;
using College.Core.Interfaces;
using College.DAL.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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

            await RemoveAllProfessorsFromCache();

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorDAL::AddProfessor");

            return professor;
        }

        public async Task<IEnumerable<Professor>> GetAllProfessors()
        {
            IEnumerable<Professor> professors;

            _logger.Log(LogLevel.Debug, "Request Received for ProfessorDAL::GetAllProfessors");

            var professorsFromCache = await _cacheDbDal.RetrieveItemFromCache(Constants.RedisCacheStore.AllProfessorsKey);

            if (!string.IsNullOrEmpty(professorsFromCache))
            {
                // content exists in Redis cache, deserilize
                professors = JsonConvert.DeserializeObject<IEnumerable<Professor>>(professorsFromCache);
            }
            else
            {
                // Retrieve the data from SQL Server
                professors = await _collegeDbContext.Professors
                    .Include(student => student.Students)
                    .ToListAsync();

                // Store a copy in Redis Server
                await _cacheDbDal.SaveOrUpdateItemToCache(Constants.RedisCacheStore.AllProfessorsKey, JsonConvert.SerializeObject(professors));
            }

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorDAL::GetAllProfessors");

            return professors;
        }

        public async Task<Professor> GetProfessorById(Guid professorId)
        {
            Professor professor = null;
            string _professorId = $"{Constants.RedisCacheStore.SingleProfessorsKey}{professorId}";

            _logger.Log(LogLevel.Debug, "Request Received for ProfessorDAL::GetProfessorById");

            var professorFromCache = await _cacheDbDal.RetrieveItemFromCache(_professorId);

            if (!string.IsNullOrEmpty(professorFromCache))
            {
                //if they are there, deserialize them
                professor = JsonConvert.DeserializeObject<Professor>(professorFromCache);
            }
            else
            {
                professor = await _collegeDbContext.Professors
                    .Where(record => record.ProfessorId == professorId)
                    .Include(student => student.Students)
                    .FirstOrDefaultAsync();

                if (professor != null)
                {
                    //and then, put them in cache
                    await _cacheDbDal.SaveOrUpdateItemToCache(_professorId, JsonConvert.SerializeObject(professor));
                }
            }

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
            retrievedProfessor.Name = professor.Name;
            retrievedProfessor.Salary = professor.Salary;
            retrievedProfessor.Teaches = professor.Teaches;
            retrievedProfessor.IsPhd = professor.IsPhd;

            await _collegeDbContext.SaveChangesAsync();

            // Update the copy in Redis Server
            string professorId = $"{Constants.RedisCacheStore.SingleProfessorsKey}{professor.ProfessorId}";
            await _cacheDbDal.SaveOrUpdateItemToCache(professorId, JsonConvert.SerializeObject(retrievedProfessor));

            // Also Remove all items from the Key
            await RemoveAllProfessorsFromCache();

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

            await RemoveAllProfessorsFromCache();

            return true;
        }

        private async Task RemoveAllProfessorsFromCache()
        {
            // Clear the item from Redis Cache
            await _cacheDbDal.DeleteItemFromCache(Constants.RedisCacheStore.AllProfessorsKey);
        }

    }

}
