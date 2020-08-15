using College.Core.Entities;
using College.Core.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace College.BLL
{

    public class ProfessorsBLL : IProfessorsBLL
    {
        private readonly IProfessorsDAL _professorDal;
        private readonly ILogger<ProfessorsBLL> _logger;

        public ProfessorsBLL(IProfessorsDAL professorDal, ILogger<ProfessorsBLL> logger)
        {
            _professorDal = professorDal;

            _logger = logger;
        }

        public Professor AddProfessor(Professor professor)
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorBLL::AddProfessor");

            var newProfessor = _professorDal.AddProfessor(professor);

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorBLL::AddProfessor");

            return newProfessor;
        }

        public async Task<IEnumerable<Professor>> GetAllProfessors()
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorBLL::GetAllProfessors");

            var allProfessors = await _professorDal.GetAllProfessors();

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorBLL::GetAllProfessors");

            return allProfessors;
        }

        public async Task<Professor> GetProfessorById(Guid professorId)
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorBLL::GetAllProfessors");

            var professor = await _professorDal.GetProfessorById(professorId);

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorBLL::GetAllProfessors");

            return professor;
        }

        public Professor UpdateProfessor(Professor professor)
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorBLL::UpdateProfessor");

            var updatedProfessor = _professorDal.UpdateProfessor(professor);

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorBLL::UpdateProfessor");

            return updatedProfessor;
        }

        public bool DeleteProfessorById(Guid id)
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorBLL::DeleteProfessorById");

            var professorDeleted = _professorDal.DeleteProfessorById(id);

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorBLL::DeleteProfessorById");

            return professorDeleted;
        }
    }

}
