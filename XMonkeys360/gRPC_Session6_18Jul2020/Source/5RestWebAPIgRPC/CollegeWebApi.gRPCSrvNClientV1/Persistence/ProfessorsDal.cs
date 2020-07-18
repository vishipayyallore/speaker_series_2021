using College.WebApi.Entities;
using College.WebApi.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace College.WebApi.Persistence
{

    public class ProfessorsDal
    {
        private readonly CollegeDbContext _collegeDbContext;

        public ProfessorsDal(CollegeDbContext collegeDbContext)
        {
            _collegeDbContext = collegeDbContext;
        }

        public IEnumerable<Professor> GetProfessors()
        {
            return _collegeDbContext.Professors
                .Include(student => student.Students)
                .ToList();
        }


        public Professor GetProfessorById(Guid id)
        {
            if (!_collegeDbContext.Professors.Any(record => record.ProfessorId == id))
            {
                return null;
            }

            return _collegeDbContext.Professors
                .Where(record => record.ProfessorId == id)
                .Include(student => student.Students)
                .FirstOrDefault();
        }

    }

}
