using College.ApplicationCore.Entities;
using College.ApplicationCore.Interfaces;
using College.GrpcServer.Protos;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using static College.GrpcServer.Protos.CollegeService;

namespace College.GrpcServer.Services
{

    public class CollegeGrpcService : CollegeServiceBase
    {
        private readonly IProfessorBLL _professorsBll;
        private readonly ILogger<CollegeGrpcService> _logger;

        public CollegeGrpcService(IProfessorBLL professorsBll, ILogger<CollegeGrpcService> logger)
        {
            _professorsBll = professorsBll;

            _logger = logger;
        }

        public override Task<NewProfessorResponse> AddProfessor(NewProfessorRequest request, ServerCallContext context)
        {
            _logger.Log(LogLevel.Debug, "Request Received for CollegeGrpcService::AddProfessor");

            var newProfessor = new NewProfessorResponse
            {
                Message = "success"
            };

            var professor = new Professor
            {
                Name = request.Name,
                Doj = request.Doj.ToDateTime(),
                Teaches = request.Teaches,
                Salary = Convert.ToDecimal(request.Salary),
                IsPhd = request.IsPhd
            };

            var results = _professorsBll.AddProfessor(professor);

            newProfessor.ProfessorId = results.ProfessorId.ToString();

            _logger.Log(LogLevel.Debug, "Returning the results from CollegeGrpcService::AddProfessor");

            return Task.FromResult(newProfessor);
        }

    }

}
