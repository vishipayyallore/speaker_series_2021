using College.WebAPI.BLL;
using College.WebAPI.Core.Entities;
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
        private readonly ProfessorsSqlBll _professorsSqlBll;

        public ProfessorsController(ILogger<ProfessorsController> logger, ProfessorsSqlBll professorsSqlBll)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _professorsSqlBll = professorsSqlBll ?? throw new ArgumentNullException(nameof(professorsSqlBll));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Professor>>> Get()
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsController::Get");

            IEnumerable<Professor> professors = await _professorsSqlBll.GetAllProfessors()
                                                        .ConfigureAwait(false);

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsController::Get");

            return Ok(professors);
        }

    }

}
