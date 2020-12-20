using College.Core.Entities;
using College.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace College.WebAPI.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProfessorsController : ControllerBase
    {

        private readonly IProfessorsBLL _professorsBLL;
        private readonly ILogger<ProfessorsController> _logger;

        public ProfessorsController(IProfessorsBLL professorsBLL, ILogger<ProfessorsController> logger)
        {
            _professorsBLL = professorsBLL;

            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Professor>> Get()
        {
            IEnumerable<Professor> professors;

            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsController::Get");

            // Going to Data Store SQL Server
            professors = _professorsBLL.GetAllProfessors();

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsController::Get");

            return Ok(professors);
        }

    }

}
