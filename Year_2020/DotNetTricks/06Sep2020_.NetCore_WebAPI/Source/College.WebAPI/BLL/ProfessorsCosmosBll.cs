using College.WebAPI.Entities;
using College.WebAPI.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace College.WebAPI.BLL
{

    public class ProfessorsCosmosBll : IProfessorsCosmosBll
    {
        private readonly IProfessorsCosmosDal _professorsCosmosDal;
        private readonly ILogger<ProfessorsCosmosBll> _logger;

        public ProfessorsCosmosBll(ILogger<ProfessorsCosmosBll> logger, IProfessorsCosmosDal professorsCosmosDal)
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

        public async Task<IEnumerable<Professor>> GetAllProfessors()
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsCosmosBll::GetAllProfessors");

            var allProfessors = await _professorsCosmosDal.GetAllProfessors();

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsCosmosBll::GetAllProfessors");

            return allProfessors;
        }

        public async Task<Professor> GetProfessorById(Guid professorId)
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsCosmosBll::GetAllProfessors");

            var professor = await _professorsCosmosDal.GetProfessorById(professorId);

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsCosmosBll::GetAllProfessors");

            return professor;
        }

        public async Task<Professor> UpdateProfessor(Professor professor)
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsCosmosBll::UpdateProfessor");

            var updatedProfessor = await _professorsCosmosDal.UpdateProfessor(professor);

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsCosmosBll::UpdateProfessor");

            return updatedProfessor;
        }

        public async Task<bool?> DeleteProfessorById(Guid id)
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsCosmosBll::DeleteProfessorById");

            var professorDeleted = await _professorsCosmosDal.DeleteProfessorById(id);

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsCosmosBll::DeleteProfessorById");

            return professorDeleted;
        }

    }

}
