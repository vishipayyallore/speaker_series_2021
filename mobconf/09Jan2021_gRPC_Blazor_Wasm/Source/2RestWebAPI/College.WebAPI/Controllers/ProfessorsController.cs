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

    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProfessorsController : ControllerBase
    {

        private readonly IProfessorsBll _professorsBll;
        private readonly ILogger<ProfessorsController> _logger;

        /*
            TODO: UNCOMMENT this method when executing https://benchmarkdotnet.org
        */
        public ProfessorsController()
        {
            _professorsBll = new Bll.ProfessorsBll();
            _logger = new Logger<ProfessorsController>(new LoggerFactory());
        }

        /*
            TODO: COMMENT this method when executing https://benchmarkdotnet.org
        */
        //public ProfessorsController(IProfessorsBll professorsBll, ILogger<ProfessorsController> logger)
        //{
        //    _professorsBll = professorsBll ?? throw new ArgumentNullException(nameof(professorsBll));

        //    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        //}

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Professor>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Professor>>> Get()
        {
            IEnumerable<Professor> professors;

            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsController::Get");

            professors = await _professorsBll.GetAllProfessors()
                                                .ConfigureAwait(false);

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsController::Get");

            return Ok(professors);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Professor), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<Professor>> GetProfessorById(Guid id)
        {
            Professor professor;

            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsController::Get");

            professor = await _professorsBll.GetProfessorById(id)
                                                .ConfigureAwait(false);

            if (professor == null)
            {
                return NotFound();
            }

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsController::Get");

            return Ok(professor);
        }

    }

}
