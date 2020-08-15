using College.Core.Entities;
using College.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace College.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorsController : ControllerBase
    {

        private readonly ILogger<ProfessorsController> _logger;
        private readonly IProfessorsBLL _professorsBLL;

        public ProfessorsController(ILogger<ProfessorsController> logger, IProfessorsBLL professorsBLL)
        {
            _logger = logger;

            _professorsBLL = professorsBLL;
        }

        [HttpPost]
        public ActionResult<Professor> AddProfessor([FromBody] Professor professor)
        {
            var createdProfessor = _professorsBLL.AddProfessor(professor);

            return Created(string.Empty, createdProfessor);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Professor>>> Get()
        {
            IEnumerable<Professor> professors;

            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsController::Get");

            professors = await _professorsBLL.GetAllProfessors();

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsController::Get");

            return Ok(professors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Professor>> GetProfessorById(Guid id)
        {
            Professor professor;

            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsController::Get");

            professor = await _professorsBLL.GetProfessorById(id);

            if (professor == null)
            {
                return NotFound();
            }

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsController::Get");

            return Ok(professor);
        }

        [HttpPut]
        public ActionResult UpdateProfessor([FromBody] Professor professor)
        {
            var _ = _professorsBLL.UpdateProfessor(professor);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProfessor(Guid id)
        {
            var professorDeleted = _professorsBLL.DeleteProfessorById(id);

            if (!professorDeleted)
            {
                return StatusCode(500, $"Unable to delete Professor with id {id}");
            }

            return NoContent();
        }

    }
}
