using College.Core.Entities;
using College.Core.Interfaces;
using College.GrpcServer.Protos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using static College.GrpcServer.Protos.CollegeService;

namespace College.GrpcServer.Services
{

    public class CollegeGrpcService : CollegeServiceBase
    {
        private readonly IProfessorsBLL _professorsBll;
        private readonly ILogger<CollegeGrpcService> _logger;

        public CollegeGrpcService(IProfessorsBLL professorsBll, ILogger<CollegeGrpcService> logger)
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

        public override async Task<AllProfessorsResonse> GetAllProfessors(Empty request, ServerCallContext context)
        {
            Stopwatch stopwatch = new Stopwatch();
            AllProfessorsResonse allProfessorsResonse = new AllProfessorsResonse();

            stopwatch.Start();

            var allProfessors = _professorsBll.GetAllProfessors();

            stopwatch.Stop();
            _logger.Log(LogLevel.Warning, $"Time Taken to Retireve a Record: {stopwatch.ElapsedMilliseconds} ms");

            allProfessorsResonse.Count = allProfessors.Count();

            foreach (var professor in allProfessors)
            {
                // TODO: Remove Technical Debt
                allProfessorsResonse.Professors.Add(GetProfessorObject(professor));
            }

            return await Task.FromResult(allProfessorsResonse);
        }

        public override async Task<GetProfessorResponse> GetProfessorById(GetProfessorRequest request, ServerCallContext context)
        {
            Stopwatch stopwatch = new Stopwatch();
            Professor professor;

            stopwatch.Start();

            // Going to Data Store SQL Server
            professor = _professorsBll.GetProfessorById(Guid.Parse(request.ProfessorId));

            stopwatch.Stop();
            _logger.Log(LogLevel.Warning, $"Time Taken to Retireve a Record: {stopwatch.ElapsedMilliseconds} ms");

            GetProfessorResponse getProfessorResponse = new GetProfessorResponse();
            getProfessorResponse = GetProfessorObject(professor);

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
