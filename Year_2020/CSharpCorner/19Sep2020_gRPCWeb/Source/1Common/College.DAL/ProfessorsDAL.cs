using College.Core.Entities;
using College.Core.Interfaces;
using College.DAL.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace College.DAL
{

    public class ProfessorsDAL : IProfessorsDAL
    {
        private readonly CollegeDbContext _collegeDbContext;
        private readonly ILogger<ProfessorsDAL> _logger;

        public ProfessorsDAL(CollegeDbContext collegeDbContext, ILogger<ProfessorsDAL> logger)
        {
            _collegeDbContext = collegeDbContext;

            _logger = logger;
        }

        public Professor AddProfessor(Professor professor)
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorDAL::AddProfessor");

            _collegeDbContext.Professors.Add(professor);

            _collegeDbContext.SaveChanges();

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorDAL::AddProfessor");

            return professor;
        }

        public IEnumerable<Professor> GetAllProfessors()
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorDAL::GetAllProfessors");

            var professors = _collegeDbContext
                    .Professors
                    .Include(student => student.Students)
                    .ToList();

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorDAL::GetAllProfessors");

            return professors;
        }

        public Professor GetProfessorById(Guid professorId)
        {
            Professor professor = null;

            _logger.Log(LogLevel.Debug, "Request Received for ProfessorDAL::GetProfessorById");

            professor = _collegeDbContext.Professors
                .Where(record => record.ProfessorId == professorId)
                .Include(student => student.Students)
                .FirstOrDefault();

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorDAL::GetProfessorById");

            return professor;
        }
    }

}
