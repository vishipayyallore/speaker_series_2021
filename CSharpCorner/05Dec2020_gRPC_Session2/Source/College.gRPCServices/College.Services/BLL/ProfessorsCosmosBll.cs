using College.Api.Entities;
using College.Api.Persistence;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace College.Api.BLL
{

    public class ProfessorsCosmosBll
    {
        private readonly ProfessorsCosmosDal _professorsCosmosDal;
        private readonly ILogger<ProfessorsCosmosBll> _logger;

        public ProfessorsCosmosBll(ILogger<ProfessorsCosmosBll> logger, ProfessorsCosmosDal professorsCosmosDal)
        {
            _professorsCosmosDal = professorsCosmosDal;

            _logger = logger;
        }

        public async Task<Professor> AddProfessor(Professor professor)
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsCosmosBll::AddProfessor");

            var newProfessor = await _professorsCosmosDal.AddProfessor(professor);

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsCosmosBll::AddProfessor");

            return newProfessor;
        }

    }

}
