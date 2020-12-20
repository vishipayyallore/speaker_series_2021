using College.ApplicationCore.Constants;
using College.ApplicationCore.Entities;
using College.ApplicationCore.Interfaces;
using College.GrpcServer.Protos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using static College.GrpcServer.Protos.CollegeService;

namespace College.GrpcServer.Services
{

    public class CollegeGrpcService : CollegeServiceBase
    {
        private readonly IProfessorBLL _professorsBll;
        private readonly ILogger<CollegeGrpcService> _logger;
        private readonly IDistributedCache _cache;

        public CollegeGrpcService(IProfessorBLL professorsBll, ILogger<CollegeGrpcService> logger, IDistributedCache cache)
        {
            _professorsBll = professorsBll;

            _logger = logger;

            _cache = cache;
        }

        public override Task<AddProfessorResponse> AddProfessor(AddProfessorRequest request, ServerCallContext context)
        {
            _logger.Log(LogLevel.Debug, "Request Received for CollegeGrpcService::AddProfessor");

            var newProfessor = new AddProfessorResponse
            {
                Message = "success"
            };

            // TODO: Remove Technical Debt
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
            IEnumerable<Professor> allProfessors;
            // Try to get content from cache
            var professorsFromCache = _cache.GetString(Constants.RedisCacheStore.AllProfessorsKey);

            if (!string.IsNullOrEmpty(professorsFromCache))
            {
                //if they are there, deserialize them
                allProfessors = JsonConvert.DeserializeObject<IEnumerable<Professor>>(professorsFromCache);
            }
            else
            {
                // Going to Data Store SQL Server
                allProfessors = _professorsBll.GetAllProfessors();

                //and then, put them in cache
                _cache.SetString(Constants.RedisCacheStore.AllProfessorsKey, 
                    JsonConvert.SerializeObject(allProfessors),
                    GetDistributedCacheEntryOptions());
            }
            stopwatch.Stop();
            _logger.Log(LogLevel.Warning, $"Time Taken to Retireve a Record: {stopwatch.ElapsedMilliseconds} ms");

            allProfessorsResonse.Count = allProfessors.Count();
            
            foreach (var professor in allProfessors)
            {
                // TODO: Remove Technical Debt
                allProfessorsResonse.Professors.Add(GetProfessorObject(professor));
            }

            return await Task.FromResult( allProfessorsResonse);
        }

        public override async Task<GetProfessorResponse> GetProfessorById(GetProfessorRequest request, ServerCallContext context)
        {
            Stopwatch stopwatch = new Stopwatch();
            GetProfessorResponse getProfessorResponse = new GetProfessorResponse();
            Professor professor;
            string professorId = $"{Constants.RedisCacheStore.SingleProfessorsKey}{request.ProfessorId}";

            stopwatch.Start();
            var professorFromCache = _cache.GetString(professorId);

            if (!string.IsNullOrEmpty(professorFromCache))
            {
                //if they are there, deserialize them
                professor = JsonConvert.DeserializeObject<Professor>(professorFromCache);
            }
            else
            {
                // Going to Data Store SQL Server
                professor = _professorsBll.GetProfessorById(Guid.Parse(request.ProfessorId));

                //and then, put them in cache
                _cache.SetString(professorId, JsonConvert.SerializeObject(professor), GetDistributedCacheEntryOptions());
            }
            stopwatch.Stop();
            _logger.Log(LogLevel.Warning, $"Time Taken to Retireve a Record: {stopwatch.ElapsedMilliseconds} ms");

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

        private DistributedCacheEntryOptions GetDistributedCacheEntryOptions()
        {
            return new DistributedCacheEntryOptions()
            {
                AbsoluteExpiration = new System.DateTimeOffset(DateTime.Now.ToUniversalTime().AddSeconds(60), new TimeSpan(0, 0, 0))
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
