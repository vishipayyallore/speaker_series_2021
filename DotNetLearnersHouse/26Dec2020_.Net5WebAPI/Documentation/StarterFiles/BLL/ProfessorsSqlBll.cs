using College.WebAPI.Core.Entities;
using College.WebAPI.DAL;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace College.WebAPI.BLL
{

    public class ProfessorsSqlBll
    {
        private readonly ProfessorsSqlDal _professorsSqlDal;
        private readonly ILogger<ProfessorsSqlBll> _logger;

        public ProfessorsSqlBll(ProfessorsSqlDal professorsSqlDal, ILogger<ProfessorsSqlBll> logger)
        {
            _professorsSqlDal = professorsSqlDal ?? throw new ArgumentNullException(nameof(professorsSqlDal));
            
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<Professor>> GetAllProfessors()
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsSqlBll::GetAllProfessors");

            var allProfessors = await _professorsSqlDal.GetAllProfessors()
                                        .ConfigureAwait(false);

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsSqlBll::GetAllProfessors");

            return allProfessors;
        }

    }

}
