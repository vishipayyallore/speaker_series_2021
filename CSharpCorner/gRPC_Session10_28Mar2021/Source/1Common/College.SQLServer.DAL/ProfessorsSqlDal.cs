using College.Core.Constants;
using College.Core.Entities;
using College.Core.Interfaces;
using College.SQLServer.DAL.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace College.SQLServer.DAL
{

    public class ProfessorsSqlDal : IProfessorsSqlDal
    {
        private readonly CollegeSqlDbContext _collegeSqlDbContext;
        private readonly ILogger<ProfessorsSqlDal> _logger;
        //private readonly IRedisCacheDbDal _cacheDbDal;

        public ProfessorsSqlDal(CollegeSqlDbContext collegeSqlDbContext, ILogger<ProfessorsSqlDal> logger/*, IRedisCacheDbDal cacheDbDal*/)
        {
            _collegeSqlDbContext = collegeSqlDbContext ?? throw new ArgumentNullException(nameof(collegeSqlDbContext));

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            //_cacheDbDal = cacheDbDal ?? throw new ArgumentNullException(nameof(cacheDbDal));
        }

        public async Task<Professor> AddProfessor(Professor professor)
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsSqlDal::AddProfessor");

            _collegeSqlDbContext.Professors.Add(professor);

            await _collegeSqlDbContext.SaveChangesAsync();

            // await RemoveProfessorDataFromCache(Constants.RedisCacheStore.AllProfessorsKey);

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsSqlDal::AddProfessor");

            return professor;
        }

        public async Task<IEnumerable<Professor>> GetAllProfessors()
        {
            IEnumerable<Professor> professors;

            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsSqlDal::GetAllProfessors");

            //var professorsFromCache = await _cacheDbDal.RetrieveItemFromCache(Constants.RedisCacheStore.AllProfessorsKey);

            //if (!string.IsNullOrEmpty(professorsFromCache))
            //{
            //    professors = JsonConvert.DeserializeObject<IEnumerable<Professor>>(professorsFromCache);
            //}
            //else
            //{
            professors = await _collegeSqlDbContext.Professors
                .Include(student => student.Students)
                .ToListAsync();

            //    await _cacheDbDal.SaveOrUpdateItemToCache(Constants.RedisCacheStore.AllProfessorsKey, JsonConvert.SerializeObject(professors));
            //}

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsSqlDal::GetAllProfessors");

            return professors;
        }

        public async Task<Professor> GetProfessorById(Guid professorId)
        {
            Professor professor = null;
            // string _professorId = GetSingleProfessorRedisCacheKey(professorId);

            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsSqlDal::GetProfessorById");

            // var professorFromCache = await _cacheDbDal.RetrieveItemFromCache(_professorId);

            //if (!string.IsNullOrEmpty(professorFromCache))
            //{
            //    professor = JsonConvert.DeserializeObject<Professor>(professorFromCache);
            //}
            //else
            //{
            professor = await _collegeSqlDbContext.Professors
                .Where(record => record.ProfessorId == professorId)
                .Include(student => student.Students)
                .FirstOrDefaultAsync();

            //    if (professor != null)
            //    {
            //        await _cacheDbDal.SaveOrUpdateItemToCache(_professorId, JsonConvert.SerializeObject(professor));
            //    }
            //}

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsSqlDal::GetProfessorById");

            return professor;
        }

        public async Task<Professor> UpdateProfessor(Professor professor)
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsSqlDal::UpdateProfessor");
            // string professorId = GetSingleProfessorRedisCacheKey(professor.ProfessorId);

            if (!_collegeSqlDbContext.Professors.Any(record => record.ProfessorId == professor.ProfessorId))
            {
                return null;
            }

            var retrievedProfessor = await _collegeSqlDbContext.Professors
                .Where(record => record.ProfessorId == professor.ProfessorId)
                .FirstOrDefaultAsync();

            retrievedProfessor.Name = professor.Name;
            retrievedProfessor.Salary = professor.Salary;
            retrievedProfessor.Teaches = professor.Teaches;
            retrievedProfessor.IsPhd = professor.IsPhd;

            await _collegeSqlDbContext.SaveChangesAsync();

            //await RemoveProfessorDataFromCache(Constants.RedisCacheStore.AllProfessorsKey);

            //await _cacheDbDal.SaveOrUpdateItemToCache(professorId, JsonConvert.SerializeObject(retrievedProfessor));

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsSqlDal::UpdateProfessor");

            return professor;
        }

        public async Task<bool> DeleteProfessorById(Guid professorId)
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsSqlDal::DeleteProfessorById");
            // string _professorId = GetSingleProfessorRedisCacheKey(professorId);

            if (!_collegeSqlDbContext.Professors.Any(record => record.ProfessorId == professorId))
            {
                return false;
            }

            var retrievedProfessor = await _collegeSqlDbContext.Professors
                .Where(record => record.ProfessorId == professorId)
                .FirstOrDefaultAsync();

            _collegeSqlDbContext.Professors.Remove(retrievedProfessor);

            await _collegeSqlDbContext.SaveChangesAsync();

            //await RemoveProfessorDataFromCache(Constants.RedisCacheStore.AllProfessorsKey);

            //await RemoveProfessorDataFromCache(_professorId);

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsSqlDal::DeleteProfessorById");

            return true;
        }

        //private async Task RemoveProfessorDataFromCache(string redisCacheKey)
        //{
        //    await _cacheDbDal.DeleteItemFromCache(redisCacheKey);
        //}

        //private string GetSingleProfessorRedisCacheKey(Guid professorId)
        //{
        //    return $"{Constants.RedisCacheStore.SingleProfessorsKey}{professorId}";
        //}
    }

}
