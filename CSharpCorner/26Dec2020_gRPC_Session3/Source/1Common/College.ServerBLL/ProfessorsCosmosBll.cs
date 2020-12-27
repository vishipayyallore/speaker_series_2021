using College.ApplicationCore.Entities;
using College.ApplicationCore.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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

        public async Task<Professor> GetProfessorById(Guid professorId)
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsCosmosBll::GetProfessorById");

            var professor = await _professorsCosmosDal.GetProfessorById(professorId)
                                                       .ConfigureAwait(false);

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsCosmosBll::GetProfessorById");

            return professor;
        }

        public async Task<IEnumerable<Professor>> GetAllProfessors()
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsCosmosBll::GetAllProfessors");

            var allProfessors = await _professorsCosmosDal.GetAllProfessors()
                                                            .ConfigureAwait(false);

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsCosmosBll::GetAllProfessors");

            return allProfessors;
        }

        public async Task<Professor> UpdateProfessor(Professor professor)
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsCosmosBll::UpdateProfessor");

            var updatedProfessor = await _professorsCosmosDal.UpdateProfessor(professor)
                                                            .ConfigureAwait(false);

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsCosmosBll::UpdateProfessor");

            return updatedProfessor;
        }

        public async Task<bool> DeleteProfessorById(Guid professorId)
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsCosmosBll::DeleteProfessorById");

            var professorDeleted = await _professorsCosmosDal.DeleteProfessorById(professorId)
                                                              .ConfigureAwait(false);

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsCosmosBll::DeleteProfessorById");

            return professorDeleted;
        }
    }

}
