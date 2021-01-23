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
using static College.GrpcServer.Protos.CollegeSvc;

namespace College.GrpcServer.Services
{

    public class CollegeService : CollegeSvcBase
    {
        private readonly IProfessorsBll _professorsBll;
        private readonly ILogger<CollegeService> _logger;
        private readonly IMapper _mapper;

        public CollegeService(IProfessorsBll professorsBll, ILogger<CollegeService> logger, IMapper mapper)
        {
            _professorsBll = professorsBll ?? throw new ArgumentNullException(nameof(professorsBll));
            
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
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
                allProfessorsResonse.Professors.Add(_mapper.Map<GetProfessorResponse>(professor));
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

        ////====================== Private Methods ======================
        //private static GetProfessorResponse GetProfessorObject(Professor professor)
        //{
        //    if (professor == null)
        //    {
        //        return new GetProfessorResponse();
        //    }

        //    return new GetProfessorResponse()
        //    {
        //        ProfessorId = professor.ProfessorId.ToString(),
        //        Name = professor.Name,
        //        Teaches = professor.Teaches,
        //        IsPhd = professor.IsPhd,
        //        Salary = decimal.ToDouble(professor.Salary),
        //        Doj = Timestamp.FromDateTime(professor.Doj.ToUniversalTime())
        //    };
        //}
        ////====================== Private Methods ======================

    }

}
