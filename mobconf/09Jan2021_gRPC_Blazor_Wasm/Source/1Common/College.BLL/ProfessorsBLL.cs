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
            _professorDal = professorDal ?? throw new ArgumentNullException(nameof(professorDal));

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<Professor>> GetAllProfessors()
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorBLL::GetAllProfessors");

            var professors = await _professorDal.GetAllProfessors()
                                                    .ConfigureAwait(false);

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorBLL::GetAllProfessors");

            return professors;
        }

        public async Task<Professor> GetProfessorById(Guid professorId)
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorBLL::GetAllProfessors");

            var professor = await _professorDal.GetProfessorById(professorId)
                                                    .ConfigureAwait(false);

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorBLL::GetAllProfessors");

            return professor;
        }

    }

}
