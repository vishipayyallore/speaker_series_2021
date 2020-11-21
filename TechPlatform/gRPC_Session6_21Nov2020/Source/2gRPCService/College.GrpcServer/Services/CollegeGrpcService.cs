using AutoMapper;
using College.Core.Entities;
using College.Core.Interfaces;
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
        private readonly IProfessorsSqlBll _professorsBll;
        private readonly ILogger<CollegeGrpcService> _logger;
        private readonly IMapper _mapper;

        public CollegeGrpcService(IProfessorsSqlBll professorsBll, ILogger<CollegeGrpcService> logger, IMapper mapper)
        {
            _professorsBll = professorsBll ?? throw new ArgumentNullException(nameof(professorsBll));

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public override async Task<NewProfessorResponse> AddProfessor(NewProfessorRequest request, ServerCallContext context)
        {
            _logger.Log(LogLevel.Debug, "Request Received for CollegeGrpcService::AddProfessor");

            var newProfessor = new NewProfessorResponse
            {
                Message = "success"
            };

            var professor = _mapper.Map<Professor>(request);

            var results = await _professorsBll.AddProfessor(professor);

            newProfessor.ProfessorId = results.ProfessorId.ToString();

            _logger.Log(LogLevel.Debug, "Returning the results from CollegeGrpcService::AddProfessor");

            return newProfessor;
        }

        public override async Task<AllProfessorsResonse> GetAllProfessors(Empty request, ServerCallContext context)
        {
            AllProfessorsResonse allProfessorsResonse = new AllProfessorsResonse();

            _logger.Log(LogLevel.Debug, "Request Received for CollegeGrpcService::GetAllProfessors");

            var allProfessors = await _professorsBll.GetAllProfessors();

            allProfessorsResonse.Count = allProfessors.Count();

            foreach (var professor in allProfessors)
            {
                // TODO: Remove Technical Debt
                allProfessorsResonse.Professors.Add(GetProfessorObject(professor));
            }

            _logger.Log(LogLevel.Debug, "Returning the results from CollegeGrpcService::GetAllProfessors");

            return allProfessorsResonse;
        }

        public override async Task<GetProfessorResponse> GetProfessorById(GetProfessorRequest request, ServerCallContext context)
        {
            _logger.Log(LogLevel.Debug, "Request Received for CollegeGrpcService::GetProfessorById");

            Professor professor = await _professorsBll.GetProfessorById(Guid.Parse(request.ProfessorId));

            GetProfessorResponse getProfessorResponse = _mapper.Map<GetProfessorResponse>(professor); 

            _logger.Log(LogLevel.Debug, "Returning the results from CollegeGrpcService::GetProfessorById");

            return getProfessorResponse;
        }

        public override async Task<UpdateProfessorResponse> UpdateProfessorById(UpdateProfessorRequest request, ServerCallContext context)
        {
            _logger.Log(LogLevel.Debug, "Request Received for CollegeGrpcService::UpdateProfessorById");

            var updatedProfessor = new UpdateProfessorResponse
            {
                Message = "success"
            };

            var professor = _mapper.Map<Professor>(request);

            professor = await _professorsBll.UpdateProfessor(professor);
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

            professorDeleted.Success = await _professorsBll.DeleteProfessorById(Guid.Parse(request.ProfessorId));

            _logger.Log(LogLevel.Debug, "Returning the results from CollegeGrpcService::DeleteProfessorById");

            return professorDeleted;
        }

        //====================== Private Methods ======================
        private GetProfessorResponse GetProfessorObject(Professor professor)
        {
            if(professor == null)
            {
                return new GetProfessorResponse();
            }

            return _mapper.Map<GetProfessorResponse>(professor);
        }
        //====================== Private Methods ======================

    }

}
