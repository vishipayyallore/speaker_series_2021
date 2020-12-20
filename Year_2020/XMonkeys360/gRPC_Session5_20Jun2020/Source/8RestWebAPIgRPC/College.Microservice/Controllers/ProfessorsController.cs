using College.Microservice.BAL;
using College.Microservice.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace College.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorsController : ControllerBase
    {
        private readonly ProfessorsBal _professorsBusiness;

        public ProfessorsController(ProfessorsBal professorsBusiness)
        {
            _professorsBusiness = professorsBusiness;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Professor>> Get()
        {
            var professors = _professorsBusiness.GetProfessors();

            return Ok(professors);
        }

        [HttpGet("{id}")]
        public ActionResult<Professor> GetProfessorById(Guid id)
        {
            var professor = _professorsBusiness.GetProfessorById(id);

            if (professor == null)
            {
                return NotFound();
            }

            return Ok(professor);
        }

        [HttpPost]
        public ActionResult<Professor> AddProfessor([FromBody]Professor professor)
        {
            var createdProfessor = _professorsBusiness.AddProfessor(professor);

            return Created(string.Empty, createdProfessor);
        }

        [HttpPut]
        public ActionResult UpdateProfessor([FromBody]Professor professor)
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

    }

}