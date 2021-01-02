using College.WebAPI.Core.Entities;
using College.WebAPI.DAL.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace College.WebAPI.DAL
{

    public class ProfessorsSqlDal
    {
        private readonly CollegeSqlDbContext _collegeSqlDbContext;
        private readonly ILogger<ProfessorsSqlDal> _logger;

        public ProfessorsSqlDal(CollegeSqlDbContext collegeSqlDbContext, ILogger<ProfessorsSqlDal> logger)
        {
            _collegeSqlDbContext = collegeSqlDbContext ?? throw new ArgumentNullException(nameof(collegeSqlDbContext));

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<Professor>> GetAllProfessors()
        {
            IEnumerable<Professor> professors;

            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsSqlDal::GetAllProfessors");

            professors = await _collegeSqlDbContext.Professors
                                .Include(student => student.Students)
                                .ToListAsync()
                                .ConfigureAwait(false);

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsSqlDal::GetAllProfessors");

            return professors;
        }

    }

}
