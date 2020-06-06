using College.ApplicationCore.Entities;
using College.ApplicationCore.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace College.ServerBLL
{

    public class ProfessorBLL : IProfessorBLL
    {
        private readonly IProfessorDAL _professorDal;
        private readonly ILogger<ProfessorBLL> _logger;

        public ProfessorBLL(IProfessorDAL professorDal, ILogger<ProfessorBLL> logger)
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

        public IEnumerable<Professor> GetAllProfessors()
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorBLL::GetAllProfessors");

            var allProfessors = _professorDal.GetAllProfessors();

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorBLL::GetAllProfessors");

            return allProfessors;
        }

        public Professor GetProfessorById(Guid professorId)
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorBLL::GetAllProfessors");

            var professor = _professorDal.GetProfessorById(professorId);

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorBLL::GetAllProfessors");

            return professor;
        }

    }

}
