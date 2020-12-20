using College.GrpcServer.Protos;
using CollegeWebApi.gRPCSrvNClientV1.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using static College.GrpcServer.Protos.CollegeService;

namespace CollegeWebApi.gRPCSrvNClientV1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class GrpcProfessorController : Controller
    {
        private readonly ILogger<GrpcProfessorController> _logger;
        private readonly IConfiguration _config;
        private readonly CollegeServiceClient _collegeServiceClient;

        public GrpcProfessorController(ILogger<GrpcProfessorController> logger, IConfiguration config)
        {
            _logger = logger;

            _config = config;

            _collegeServiceClient = CollegeServiceClientHelper.GetCollegeServiceClient(_config["RPCService:ServiceUrl"]);
        }

        [HttpPost]
        public async Task<ActionResult<AddProfessorResponse>> AddProfessor([FromBody] AddProfessorRequest professor)
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsController::AddProfessor");

            var results = await _collegeServiceClient.AddProfessorAsync(professor);

            _logger.Log(LogLevel.Debug, "Sending Response from ProfessorsController::AddProfessor");

            return Created(string.Empty, results);
        }

    }
}
