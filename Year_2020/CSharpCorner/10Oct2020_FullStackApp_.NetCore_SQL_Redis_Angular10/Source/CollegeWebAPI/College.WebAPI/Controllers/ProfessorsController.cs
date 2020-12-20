using College.Core.Entities;
using College.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace College.WebAPI.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProfessorsController : ControllerBase
    {

        private readonly ILogger<ProfessorsController> _logger;
        private readonly IProfessorsSqlBll _professorsSqlBll;
        private readonly IRedisCacheDbDal _cacheDbDal;

        public ProfessorsController(ILogger<ProfessorsController> logger, 
            IProfessorsSqlBll professorsSqlBll, IRedisCacheDbDal cacheDbDal)
        {
            _logger = logger;

            _professorsSqlBll = professorsSqlBll;

            _cacheDbDal = cacheDbDal;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Professor>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Professor>>> Get()
        {
            IEnumerable<Professor> professors;

            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsController::Get");

            professors = await _professorsSqlBll.GetAllProfessors();

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsController::Get");

            return Ok(professors);
        }

        [HttpGet("{id}", Name = nameof(GetProfessorById))]
        [ProducesResponseType(typeof(Professor), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<Professor>> GetProfessorById(Guid id)
        {
            Professor professor;
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsController::GetProfessorById");

            professor = await _professorsSqlBll.GetProfessorById(id);

            if (professor == null)
            {
                return NotFound();
            }

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsController::GetProfessorById");

            return Ok(professor);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Professor), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<Professor>> AddProfessor([FromBody] Professor professor)
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsController::AddProfessor");

            var createdProfessor = await _professorsSqlBll.AddProfessor(professor);

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsController::AddProfessor");

            return CreatedAtRoute(routeName: nameof(GetProfessorById),
                                  routeValues: new { id = createdProfessor.ProfessorId },
                                  value: createdProfessor);
        }

        // PUT: HTTP 200 / HTTP 204 should imply "resource updated successfully". 
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<ActionResult> UpdateProfessor([FromBody] Professor professor)
        {
            var _ = await _professorsSqlBll.UpdateProfessor(professor);

            return NoContent();
        }

        // DELETE: HTTP 200 / HTTP 204 should imply "resource deleted successfully".
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> DeleteProfessor(Guid id)
        {
            var professorDeleted = await _professorsSqlBll.DeleteProfessorById(id);

            if (!professorDeleted)
            {
                return StatusCode(500, $"Unable to delete Professor with id {id}");
            }

            return NoContent();
        }

    }

}
