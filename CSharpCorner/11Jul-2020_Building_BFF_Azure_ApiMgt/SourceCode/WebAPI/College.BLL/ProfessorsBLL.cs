using College.Core.Entities;
using College.Core.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

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
