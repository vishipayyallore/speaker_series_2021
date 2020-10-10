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
        private readonly ProfessorsBll _professorsBll;

        public CollegeGrpcService(ProfessorsBll professorsBll)
        {
            _professorsBll = professorsBll;
        }

        public override Task<NewProfessorResponse> AddProfessor(NewProfessorRequest request, ServerCallContext context)
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

            var results = _professorsBll.AddProfessor(professor);

            newProfessor.ProfessorId = results.ProfessorId.ToString();

            return Task.FromResult(newProfessor);
        }

    }

}
