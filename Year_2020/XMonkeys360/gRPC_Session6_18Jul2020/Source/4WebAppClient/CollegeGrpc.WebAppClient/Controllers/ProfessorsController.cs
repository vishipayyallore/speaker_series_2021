using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using College.ApplicationCore.Entities;
using College.GrpcServer.Protos;
using CollegeGrpc.WebAppClient.Helpers;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using static College.GrpcServer.Protos.CollegeService;

namespace CollegeGrpc.WebAppClient.Controllers
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

        [HttpGet]
        public async Task<IEnumerable<Professor>> Get()
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsController::Get");
            IList<Professor> professors = new List<Professor>();

            // Retrieve Multiple Rows
            var allProfessors = await _collegeServiceClient.GetAllProfessorsAsync(new Empty());

            foreach (var professor in allProfessors.Professors)
            {
                professors.Add(GetProfessorObject(professor));
            }

            _logger.Log(LogLevel.Debug, "Sending Response from ProfessorsController::Get");

            return professors;
        }

        [HttpGet("{professorId}")]
        public async Task<Professor> GetProfessorById(string professorId)
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsController::GetProfessorById");

            // Retrieve Single Professor
            var professorRequest = new GetProfessorRequest { ProfessorId = professorId };
            var singleProfessor = await _collegeServiceClient.GetProfessorByIdAsync(professorRequest);

            Professor professor = GetProfessorObject(singleProfessor);

            _logger.Log(LogLevel.Debug, "Sending Response from ProfessorsController::GetProfessorById");
            return professor;
        }

        //====================== Private Methods ======================
        private static Professor GetProfessorObject(GetProfessorResponse professor)
        {
            return new Professor()
            {
                ProfessorId = Guid.Parse(professor.ProfessorId),
                Name = professor.Name,
                Teaches = professor.Teaches,
                IsPhd = professor.IsPhd,
                Salary = Convert.ToDecimal(professor.Salary),
                Doj = professor.Doj.ToDateTime()
            };
        }
        //====================== Private Methods ======================

    }


}
