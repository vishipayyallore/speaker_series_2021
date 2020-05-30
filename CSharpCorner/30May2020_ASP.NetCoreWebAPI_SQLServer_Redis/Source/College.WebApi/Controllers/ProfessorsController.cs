using College.WebApi.BAL;
using College.WebApi.Common;
using College.WebApi.Entities;
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
        private readonly ProfessorsBal _professorsBusiness;
        private readonly IDistributedCache _cache;

        public ProfessorsController(ProfessorsBal professorsBusiness, IDistributedCache cache)
        {
            _professorsBusiness = professorsBusiness;

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
                professors = _professorsBusiness.GetProfessors();

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
                professor = _professorsBusiness.GetProfessorById(id);

                //and then, put them in cache
                _cache.SetString(professorId, JsonConvert.SerializeObject(professor), GetDistributedCacheEntryOptions());
            }

            if (professor == null)
            {
                return NotFound();
            }

            return Ok(professor);
        }

        [HttpPost]
        public ActionResult<Professor> AddProfessor([FromBody] Professor professor)
        {
            var createdProfessor = _professorsBusiness.AddProfessor(professor);

            return Created(string.Empty, createdProfessor);
        }

        [HttpPut]
        public ActionResult UpdateProfessor([FromBody] Professor professor)
        {
            var _ = _professorsBusiness.UpdateProfessor(professor);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProfessor(Guid id)
        {
            var professorDeleted = _professorsBusiness.DeleteProfessorById(id);

            if (!professorDeleted)
            {
                return StatusCode(500, $"Unable to delete Professor with id {id}");
            }

            return NoContent();
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