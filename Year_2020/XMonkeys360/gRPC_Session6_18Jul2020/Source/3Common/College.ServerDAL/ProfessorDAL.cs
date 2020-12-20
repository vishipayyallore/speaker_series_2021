using College.ApplicationCore.Entities;
using College.ApplicationCore.Interfaces;
using College.ServerDAL.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace College.ServerDAL
{

    public class ProfessorDAL : IProfessorDAL
    {
        private readonly CollegeDbContext _collegeDbContext;
        private readonly ILogger<ProfessorDAL> _logger;

        public ProfessorDAL(CollegeDbContext collegeDbContext, ILogger<ProfessorDAL> logger)
        {
            _collegeDbContext = collegeDbContext;

            _logger = logger;
        }

        public async Task<Professor> AddProfessor(Professor professor)
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorDAL::AddProfessor");

            _collegeDbContext.Professors.Add(professor);

            await _collegeDbContext.SaveChangesAsync();

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorDAL::AddProfessor");

            return professor;
        }

        public async Task<IEnumerable<Professor>> GetAllProfessors()
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorDAL::GetAllProfessors");

            var professors = await _collegeDbContext.Professors.ToListAsync();

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
                .FirstOrDefaultAsync();

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorDAL::GetProfessorById");

            return professor;
        }
    }

}
