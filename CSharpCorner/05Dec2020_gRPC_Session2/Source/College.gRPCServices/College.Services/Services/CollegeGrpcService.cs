using College.Api.BLL;
using College.Api.Entities;
using College.Services.Protos;
using Grpc.Core;
using System;
using System.Threading.Tasks;

namespace College.Services.Services
{

    public class CollegeGrpcService : CollegeService.CollegeServiceBase
    {
        private readonly ProfessorsBll _professorsSQLBll;
        private readonly ProfessorsCosmosBll _professorsCosmosBll;

        public CollegeGrpcService(ProfessorsBll professorsBll, ProfessorsCosmosBll professorsCosmosBll)
        {
            _professorsSQLBll = professorsBll ?? throw new ArgumentNullException(nameof(professorsBll));
            
            _professorsCosmosBll = professorsCosmosBll ?? throw new ArgumentNullException(nameof(professorsCosmosBll));
        }

        public override async Task<NewProfessorResponse> AddProfessor(NewProfessorRequest request, ServerCallContext context)
        {
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

            var results = await _professorsSQLBll.AddProfessor(professor).ConfigureAwait(false);
            newProfessor.ProfessorId = results.ProfessorId.ToString();

            var results1 = await _professorsCosmosBll.AddProfessor(professor).ConfigureAwait(false);
            Console.WriteLine($"Professor Id (Cosmos Db): {results1.ProfessorId}");

            return newProfessor;
        }

    }

}
