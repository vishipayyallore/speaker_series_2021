using College.WebApi.BAL;
using College.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace College.WebApi.Controllers
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

    }

}