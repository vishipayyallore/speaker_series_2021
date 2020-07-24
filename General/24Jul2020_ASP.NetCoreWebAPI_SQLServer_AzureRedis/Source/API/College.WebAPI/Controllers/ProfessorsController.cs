using College.Core.Constants;
using College.Core.Entities;
using College.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace College.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorsController : ControllerBase
    {
        private readonly IProfessorsBLL _professorsBLL;
        private readonly ILogger<ProfessorsController> _logger;
        private readonly IDistributedCache _cache;

        public ProfessorsController(ILogger<ProfessorsController> logger, IProfessorsBLL professorsBLL, 
            IDistributedCache cache)
        {
            _logger = logger;

            _professorsBLL = professorsBLL;

            _cache = cache;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Professor>> Get()
        {
            IEnumerable<Professor> professors;

            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsController::Get");

            // Try to get content from cache
            var professorsFromCache = _cache.GetString(Constants.RedisCacheStore.AllProfessorsKey);

            if (!string.IsNullOrEmpty(professorsFromCache))
            {
                //if they are there, deserialize them
                professors = JsonConvert.DeserializeObject<IEnumerable<Professor>>(professorsFromCache);
            }
            else
            {
                // Going to Data Store SQL Server
                professors = _professorsBLL.GetAllProfessors();

                //and then, put them in cache
                _cache.SetString(Constants.RedisCacheStore.AllProfessorsKey, JsonConvert.SerializeObject(professors),
                        GetDistributedCacheEntryOptions());
            }

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsController::Get");

            return Ok(professors);
        }

        [HttpGet("{id}")]
        public ActionResult<Professor> GetProfessorById(Guid id)
        {
            Professor professor;
            string professorId = $"{Constants.RedisCacheStore.SingleProfessorsKey}{id}";

            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsController::Get");

            var professorFromCache = _cache.GetString(professorId);
            if (!string.IsNullOrEmpty(professorFromCache))
            {
                //if they are there, deserialize them
                professor = JsonConvert.DeserializeObject<Professor>(professorFromCache);
            }
            else
            {
                // Going to Data Store SQL Server
                professor = _professorsBLL.GetProfessorById(id);

                //and then, put them in cache
                _cache.SetString(professorId, JsonConvert.SerializeObject(professor), GetDistributedCacheEntryOptions());
            }

            if (professor == null)
            {
                return NotFound();
            }

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsController::Get");

            return Ok(professor);
        }

        private DistributedCacheEntryOptions GetDistributedCacheEntryOptions()
        {
            return new DistributedCacheEntryOptions()
            {
                AbsoluteExpiration = new System.DateTimeOffset(DateTime.Now.ToUniversalTime().AddSeconds(60), new TimeSpan(0, 0, 0))
            };
        }
    }
}
