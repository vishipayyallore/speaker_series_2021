using College.ApplicationCore.Constants;
using College.ApplicationCore.Entities;
using College.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace College.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorsController : ControllerBase
    {
        private readonly IProfessorBLL _professorBLL;
        private readonly IDistributedCache _cache;

        public ProfessorsController(IProfessorBLL professorBusiness, IDistributedCache cache)
        {
            _professorBLL = professorBusiness;

            _cache = cache;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Professor>> Get()
        {
            IEnumerable<Professor> professors;
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
                professors = _professorBLL.GetAllProfessors();

                //and then, put them in cache
                _cache.SetString(Constants.RedisCacheStore.AllProfessorsKey, JsonConvert.SerializeObject(professors),
                        GetDistributedCacheEntryOptions());
            }

            return Ok(professors);
        }

        [HttpGet("{id}")]
        public ActionResult<Professor> GetProfessorById(Guid id)
        {
            Professor professor;
            string professorId = $"{Constants.RedisCacheStore.SingleProfessorsKey}{id}";

            var professorFromCache = _cache.GetString(professorId);
            if (!string.IsNullOrEmpty(professorFromCache))
            {
                //if they are there, deserialize them
                professor = JsonConvert.DeserializeObject<Professor>(professorFromCache);
            }
            else
            {
                // Going to Data Store SQL Server
                professor = _professorBLL.GetProfessorById(id);

                //and then, put them in cache
                _cache.SetString(professorId, JsonConvert.SerializeObject(professor), GetDistributedCacheEntryOptions());
            }

            if (professor == null)
            {
                return NotFound();
            }

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