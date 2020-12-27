using College.ApplicationCore.Entities;
using College.ApplicationCore.Interfaces;
using College.GrpcServer.Protos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
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

        public override async Task<GetProfessorResponse> GetProfessorById(GetProfessorRequest request, ServerCallContext context)
        {
            _logger.Log(LogLevel.Debug, "Request Received for CollegeGrpcService::GetProfessorById");

            //Professor professor = await _professorsSqlBll.GetProfessorById(Guid.Parse(request.ProfessorId))
            //                                                .ConfigureAwait(false);

            Professor professor = await _professorsCosmosBll.GetProfessorById(Guid.Parse(request.ProfessorId))
                                                            .ConfigureAwait(false);

            GetProfessorResponse getProfessorResponse = GetProfessorObject(professor);

            _logger.Log(LogLevel.Debug, "Returning the results from CollegeGrpcService::GetProfessorById");

            return getProfessorResponse;
        }

        public override async Task<AllProfessorsResonse> GetAllProfessors(Empty request, ServerCallContext context)
        {
            AllProfessorsResonse allProfessorsResonse = new AllProfessorsResonse();

            _logger.Log(LogLevel.Debug, "Request Received for CollegeGrpcService::GetAllProfessors");

            //var allProfessors = await _professorsSqlBll.GetAllProfessors()
            //                                                .ConfigureAwait(false);

            var allProfessors = await _professorsCosmosBll.GetAllProfessors()
                                                            .ConfigureAwait(false);

            allProfessorsResonse.Count = allProfessors.Count();

            foreach (var professor in allProfessors)
            {
                // TODO: Remove Technical Debt
                allProfessorsResonse.Professors.Add(GetProfessorObject(professor));
            }

            _logger.Log(LogLevel.Debug, "Returning the results from CollegeGrpcService::GetAllProfessors");

            return allProfessorsResonse;
        }

        public override async Task<UpdateProfessorResponse> UpdateProfessorById(UpdateProfessorRequest request, ServerCallContext context)
        {
            _logger.Log(LogLevel.Debug, "Request Received for CollegeGrpcService::UpdateProfessorById");

            var updatedProfessor = new UpdateProfessorResponse
            {
                Message = "success"
            };

            var professor = new Professor
            {
                ProfessorId = Guid.Parse(request.ProfessorId),
                Name = request.Name,
                Teaches = request.Teaches,
                Salary = Convert.ToDecimal(request.Salary),
                IsPhd = request.IsPhd
            };

            //professor = await _professorsSqlBll.UpdateProfessor(professor)
            //                                        .ConfigureAwait(false);

            professor = await _professorsCosmosBll.UpdateProfessor(professor)
                                                    .ConfigureAwait(false);

            updatedProfessor.Professor = GetProfessorObject(professor);

            _logger.Log(LogLevel.Debug, "Returning the results from CollegeGrpcService::UpdateProfessorById");

            return updatedProfessor;
        }

        public override async Task<DeleteProfessorResponse> DeleteProfessorById(DeleteProfessorRequest request, ServerCallContext context)
        {
            _logger.Log(LogLevel.Debug, "Request Received for CollegeGrpcService::DeleteProfessorById");

            var professorDeleted = new DeleteProfessorResponse
            {
                ProfessorId = request.ProfessorId.ToString(),
                Message = "Professor Deleted"
            };

            //professorDeleted.Success = await _professorsSqlBll
            //                                    .DeleteProfessorById(Guid.Parse(request.ProfessorId))
            //                                    .ConfigureAwait(false);
            professorDeleted.Success = await _professorsCosmosBll
                                                .DeleteProfessorById(Guid.Parse(request.ProfessorId))
                                                .ConfigureAwait(false);

            _logger.Log(LogLevel.Debug, "Returning the results from CollegeGrpcService::DeleteProfessorById");

            return professorDeleted;
        }

        //====================== Private Methods ======================
        private static GetProfessorResponse GetProfessorObject(Professor professor)
        {
            if (professor == null)
            {
                return new GetProfessorResponse();
            }

            return new GetProfessorResponse()
            {
                ProfessorId = professor.ProfessorId.ToString(),
                Name = professor.Name,
                Teaches = professor.Teaches,
                IsPhd = professor.IsPhd,
                Salary = decimal.ToDouble(professor.Salary),
                Doj = Timestamp.FromDateTime(professor.Doj.ToUniversalTime())
            };
        }
        //====================== Private Methods ======================
    }

}
