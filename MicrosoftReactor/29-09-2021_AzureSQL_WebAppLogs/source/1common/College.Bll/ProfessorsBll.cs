using College.Core.Entities;
using College.Core.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace College.Bll
{
    public class ProfessorsBll : IProfessorsBll
    {
        private readonly IProfessorsSqlDal _professorsSqlDal;
        private readonly ILogger<ProfessorsBll> _logger;

        public ProfessorsBll(IProfessorsSqlDal professorsSqlDal, ILogger<ProfessorsBll> logger)
        {
            _professorsSqlDal = professorsSqlDal ?? throw new ArgumentNullException(nameof(professorsSqlDal));

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<Professor>> GetAllProfessors()
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsBll::GetAllProfessors");

            var allProfessors = await _professorsSqlDal.GetAllProfessors();

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsBll::GetAllProfessors");

            return allProfessors;
        }

    }

}
