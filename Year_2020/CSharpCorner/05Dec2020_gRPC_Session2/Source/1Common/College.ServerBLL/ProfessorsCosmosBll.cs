using College.ApplicationCore.Entities;
using College.ApplicationCore.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace College.ServerBLL
{

    public class ProfessorsCosmosBll : IProfessorsCosmosBll
    {
        private readonly IProfessorsCosmosDal _professorsCosmosDal;
        private readonly ILogger<ProfessorsCosmosBll> _logger;

        public ProfessorsCosmosBll(IProfessorsCosmosDal professorsCosmosDal, 
            ILogger<ProfessorsCosmosBll> logger)
        {
            _professorsCosmosDal = professorsCosmosDal ?? throw new ArgumentNullException(nameof(professorsCosmosDal));
            
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
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
