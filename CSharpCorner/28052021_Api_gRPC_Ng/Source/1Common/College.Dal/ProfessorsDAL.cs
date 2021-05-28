using College.Core.Entities;
using College.Core.Interfaces;
using College.Dal.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace College.Dal
{

    public class ProfessorsDal : IProfessorsDal
    {
        private readonly CollegeDbContext _collegeDbContext;
        private readonly ILogger<ProfessorsDal> _logger;

        public ProfessorsDal(CollegeDbContext collegeDbContext, ILogger<ProfessorsDal> logger)
        {
            _collegeDbContext = collegeDbContext ?? throw new ArgumentNullException(nameof(collegeDbContext));

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<Professor>> GetAllProfessors()
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorDAL::GetAllProfessors");

            var professors = await _collegeDbContext.Professors
                                                        .Include(student => student.Students)
                                                        .ToListAsync()
                                                        .ConfigureAwait(false);

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorDAL::GetAllProfessors");

            return professors;
        }

        public async Task<Professor> GetProfessorById(Guid professorId)
        {
            Professor professor = null;

            _logger.Log(LogLevel.Debug, "Request Received for ProfessorDAL::GetProfessorById");

            professor = await _collegeDbContext.Professors
                                                .Where(record => record.ProfessorId == professorId)
                                                .Include(student => student.Students)
                                                .FirstOrDefaultAsync()
                                                .ConfigureAwait(false);

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorDAL::GetProfessorById");

            return professor;
        }

    }

}
