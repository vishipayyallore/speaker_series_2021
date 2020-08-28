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
    public class ProfessorsV2Controller : ControllerBase
    {
        private readonly ILogger<ProfessorsV2Controller> _logger;
        private readonly IProfessorsCosmosBll _professorsCosmosBll;
        private readonly IRedisCacheDbDal _cacheDbDal;

        public ProfessorsV2Controller(ILogger<ProfessorsV2Controller> logger, IProfessorsCosmosBll professorsCosmosBll,
            IRedisCacheDbDal cacheDbDal)
        {
            _logger = logger;

            _professorsCosmosBll = professorsCosmosBll;

            _cacheDbDal = cacheDbDal;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Professor>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Professor>>> Get()
        {
            IEnumerable<Professor> professors;

            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsV2Controller::Get");

            professors = await _professorsCosmosBll.GetAllProfessors();

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsV2Controller::Get");

            return Ok(professors);
        }

        [HttpGet("{id}", Name = nameof(GetProfessorByIdV2))]
        [ProducesResponseType(typeof(Professor), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<Professor>> GetProfessorByIdV2(Guid id)
        {
            Professor professor;
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsV2Controller::GetProfessorByIdV2");

            professor = await _professorsCosmosBll.GetProfessorById(id);

            if (professor == null)
            {
                return NotFound();
            }

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsV2Controller::GetProfessorByIdV2");

            return Ok(professor);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Professor), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<Professor>> AddProfessor([FromBody] Professor professor)
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsV2Controller::AddProfessor");

            var createdProfessor = await _professorsCosmosBll.AddProfessor(professor);

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsV2Controller::AddProfessor");

            return CreatedAtRoute(routeName: nameof(GetProfessorByIdV2),
                                  routeValues: new { id = createdProfessor.ProfessorId },
                                  value: createdProfessor);
        }

        // PUT: HTTP 200 / HTTP 204 should imply "resource updated successfully". 
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<ActionResult> UpdateProfessor([FromBody] Professor professor)
        {
            var professorModified = await _professorsCosmosBll.UpdateProfessor(professor);

            if (professorModified == null)
            {
                return StatusCode(404, $"Unable to find Professor with id {professor.ProfessorId}");
            }

            return NoContent();
        }

        // DELETE: HTTP 200 / HTTP 204 should imply "resource deleted successfully".
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> DeleteProfessor(Guid id)
        {
            var professorDeleted = await _professorsCosmosBll.DeleteProfessorById(id);

            if (professorDeleted == null)
            {
                return StatusCode(404, $"Unable to find Professor with id {id}");
            }
            else if(!(bool)professorDeleted)
            {
                return StatusCode(500, $"Unable to delete Professor with id {id}");
            }

            return NoContent();
        }

    }
}
