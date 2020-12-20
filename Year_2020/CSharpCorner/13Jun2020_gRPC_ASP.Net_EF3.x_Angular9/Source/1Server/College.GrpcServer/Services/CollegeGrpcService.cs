using College.ApplicationCore.Entities;
using College.ApplicationCore.Interfaces;
using College.GrpcServer.Protos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public override async Task<AllProfessorsResonse> GetAllProfessors(Empty request, ServerCallContext context)
        {
            _logger.Log(LogLevel.Debug, "Request Received for CollegeGrpcService::GetAllProfessors");

            AllProfessorsResonse allProfessorsResonse = new AllProfessorsResonse();
            IEnumerable<Professor> allProfessors;

            // Going to Data Store SQL Server
            allProfessors = _professorsBll.GetAllProfessors();

            allProfessorsResonse.Count = allProfessors.Count();

            foreach (var professor in allProfessors)
            {
                // TODO: Remove Technical Debt
                allProfessorsResonse.Professors.Add(GetProfessorObject(professor));
            }

            _logger.Log(LogLevel.Debug, "Returing the response from CollegeGrpcService::GetAllProfessors");
            return await Task.FromResult(allProfessorsResonse);
        }

        public override async Task<GetProfessorResponse> GetProfessorById(GetProfessorRequest request, ServerCallContext context)
        {
            _logger.Log(LogLevel.Debug, "Request Received for CollegeGrpcService::GetProfessorById");
            GetProfessorResponse getProfessorResponse = new GetProfessorResponse();
            Professor professor;

            // Going to Data Store SQL Server
            professor = _professorsBll.GetProfessorById(Guid.Parse(request.ProfessorId));

            getProfessorResponse = GetProfessorObject(professor);

            _logger.Log(LogLevel.Debug, "Returing the response from CollegeGrpcService::GetProfessorById");
            return await Task.FromResult(getProfessorResponse);
        }

        //====================== Private Methods ======================
        private static GetProfessorResponse GetProfessorObject(Professor professor)
        {
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

/*
 
public override async Task<AllProfessorsResonse> GetAllProfessors(Empty request, ServerCallContext context)
        {
            AllProfessorsResonse allProfessorsResonse = new AllProfessorsResonse();

            var allProfessors = _professorsBll.GetAllProfessors();

            allProfessorsResonse.Count = allProfessors.Count();

            foreach (var professor in allProfessors)
            {
                allProfessorsResonse.Professors.Add(GetProfessorObject(professor));
            }

            return await Task.FromResult( allProfessorsResonse);
        }

public override async Task<GetProfessorResponse> GetProfessorById(GetProfessorRequest request, ServerCallContext context)
        {
            GetProfessorResponse getProfessorResponse = new GetProfessorResponse();

            var professor = _professorsBll.GetProfessorById(Guid.Parse(request.ProfessorId));

            getProfessorResponse = GetProfessorObject(professor);

            return await Task.FromResult(getProfessorResponse);
        }

*/
