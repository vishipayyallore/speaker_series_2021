using College.ApplicationCore.Entities;
using College.ApplicationCore.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace College.ServerBLL
{
    public class ProfessorsSqlBll : IProfessorsSqlBll
    {
        private readonly IProfessorsSqlDal _professorsData;
        private readonly ILogger<ProfessorsSqlBll> _logger;

        public ProfessorsSqlBll(IProfessorsSqlDal professorsData, ILogger<ProfessorsSqlBll> logger)
        {
            _professorsData = professorsData ?? throw new ArgumentNullException(nameof(professorsData));

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Professor> AddProfessor(Professor professor)
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsSqlBll::AddProfessor");

            var newProfessor = await _professorsData.AddProfessor(professor);

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsSqlBll::AddProfessor");

            return newProfessor;
        }

    }

}
