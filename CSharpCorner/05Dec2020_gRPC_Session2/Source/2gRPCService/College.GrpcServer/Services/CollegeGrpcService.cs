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
        private readonly IProfessorsSqlBll _professorsSqlBll;
        private readonly IProfessorsCosmosBll _professorsCosmosBll;
        private readonly ILogger<CollegeGrpcService> _logger;

        public CollegeGrpcService(IProfessorsSqlBll professorsSqlBll, IProfessorsCosmosBll professorsCosmosBll, 
            ILogger<CollegeGrpcService> logger)
        {
            _professorsSqlBll = professorsSqlBll ?? throw new ArgumentNullException(nameof(professorsSqlBll));
            
            _professorsCosmosBll = professorsCosmosBll ?? throw new ArgumentNullException(nameof(professorsCosmosBll));
            
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public override async Task<NewProfessorResponse> AddProfessor(NewProfessorRequest request, ServerCallContext context)
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

            var results = await _professorsSqlBll.AddProfessor(professor).ConfigureAwait(false);
            newProfessor.ProfessorId = results.ProfessorId.ToString();

            var results1 = await _professorsCosmosBll.AddProfessor(professor).ConfigureAwait(false);
            Console.WriteLine($"Professor Id (Cosmos Db): {results1.ProfessorId}");

            _logger.Log(LogLevel.Debug, "Returning the results from CollegeGrpcService::AddProfessor");

            return newProfessor;
        }

    }

}
