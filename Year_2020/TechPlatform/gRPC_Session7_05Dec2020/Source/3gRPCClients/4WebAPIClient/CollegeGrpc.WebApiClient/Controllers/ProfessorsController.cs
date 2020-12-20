using College.GrpcServer.Protos;
using CollegeGrpc.WebApiClient.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using static College.GrpcServer.Protos.CollegeService;

namespace CollegeGrpc.WebApiClient.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProfessorsController : ControllerBase
    {

        private readonly ILogger<ProfessorsController> _logger;
        private readonly IConfiguration _config;
        private readonly CollegeServiceClient _collegeServiceClient;

        public ProfessorsController(ILogger<ProfessorsController> logger, IConfiguration config)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _config = config ?? throw new ArgumentNullException(nameof(config));

            _collegeServiceClient = CollegeServiceClientHelper.GetCollegeServiceClient(_config["RPCService:ServiceUrl"]);
        }

        [HttpPost]
        public async Task<ActionResult<NewProfessorResponse>> AddProfessor([FromBody] NewProfessorRequest professor)
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsController::AddProfessor");

            var results = await _collegeServiceClient.AddProfessorAsync(professor);

            _logger.Log(LogLevel.Debug, "Sending Response from ProfessorsController::AddProfessor");

            return Created(string.Empty, results);
        }

    }

}
