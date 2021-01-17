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
        private readonly IProfessorsDal _professorDal;
        private readonly ILogger<ProfessorsBll> _logger;

        /*
            TODO: UNCOMMENT this method when executing https://benchmarkdotnet.org
        */
        //public ProfessorsBll()
        //{
        //    _professorDal = new Dal.ProfessorsDal();

        //    _logger = new Logger<ProfessorsBll>(new LoggerFactory());
        //}

        /*
            TODO: COMMENT this method when executing https://benchmarkdotnet.org
        */
        public ProfessorsBll(IProfessorsDal professorDal, ILogger<ProfessorsBll> logger)
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
