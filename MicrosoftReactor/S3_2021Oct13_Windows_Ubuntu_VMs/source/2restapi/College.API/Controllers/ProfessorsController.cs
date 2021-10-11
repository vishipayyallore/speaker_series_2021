using College.Core.Entities;
using College.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace College.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProfessorsController : ControllerBase
    {
        private readonly ILogger<ProfessorsController> _logger;
        private readonly IProfessorsBll _professorsBll;

        public ProfessorsController(ILogger<ProfessorsController> logger, IProfessorsBll professorsBll)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _professorsBll = professorsBll ?? throw new ArgumentNullException(nameof(professorsBll));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Professor>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Professor>>> Get()
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsController::Get");

            IEnumerable<Professor> professors = await _professorsBll.GetAllProfessors();

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsController::Get");

            return Ok(professors);
        }
    }
}
