using College.Core.Entities;
using College.GrpcServer.Protos;
using CollegeGrpc.WebApiClient.Helpers;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static College.GrpcServer.Protos.CollegeService;

namespace CollegeGrpc.WebApiClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorsController : ControllerBase
    {
        private readonly ILogger<ProfessorsController> _logger;
        private readonly IConfiguration _config;
        private readonly CollegeServiceClient _collegeServiceClient;

        public ProfessorsController(ILogger<ProfessorsController> logger, IConfiguration config)
        {
            _logger = logger;

            _config = config;

            _collegeServiceClient = CollegeServiceClientHelper.GetCollegeServiceClient(_config["RPCService:ServiceUrl"]);
        }

        [HttpPost]
        public async Task<ActionResult<NewProfessorResponse>> AddProfessor([FromBody] NewProfessorRequest professor)
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsController::AddProfessor");

            var createdProfessor = await _collegeServiceClient.AddProfessorAsync(professor);

            _logger.Log(LogLevel.Debug, "Sending Response from ProfessorsController::AddProfessor");

            return Created(string.Empty, createdProfessor);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Professor>>> Get()
        {
            IList<Professor> professors = new List<Professor>();

            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsController::Get");

            // Going to Data Store SQL Server
            var allProfessors = await _collegeServiceClient.GetAllProfessorsAsync(new Empty());

            foreach (var prof in allProfessors.Professors)
            {
                professors.Add(GetProfessor(prof));
            }

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsController::Get");

            return Ok(professors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Professor>> GetProfessorById(Guid professorId)
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsController::Get");

            var professorRequest = new GetProfessorRequest { ProfessorId = professorId.ToString() };

            var _professor = await _collegeServiceClient.GetProfessorByIdAsync(professorRequest);

            if (_professor == null)
            {
                return NotFound();
            }

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsController::Get");

            return Ok(GetProfessor(_professor));
        }

        //====================== Private Methods ======================
        private Professor GetProfessor(GetProfessorResponse prof)
        {
            return new Professor
            {
                ProfessorId = Guid.Parse(prof.ProfessorId),
                Name = prof.Name,
                Doj = prof.Doj.ToDateTime(),
                Teaches = prof.Teaches,
                Salary = Convert.ToDecimal(prof.Salary),
                IsPhd = prof.IsPhd
            };
        }
        //====================== Private Methods ======================
    }
}
