using College.Microservice.Entities;
using College.Microservice.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace College.Services.Persistence
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

        public Professor AddProfessor(Professor professor)
        {
            _collegeDbContext.Professors.Add(professor);

            _collegeDbContext.SaveChanges();

            return professor;
        }


        public Professor UpdateProfessor(Professor professor)
        {
            if (!_collegeDbContext.Professors.Any(record => record.ProfessorId == professor.ProfessorId))
            {
                return null;
            }


            var retrievedProfessor = _collegeDbContext.Professors.Where(record => record.ProfessorId == professor.ProfessorId).FirstOrDefault();

            // Modifying the data
            retrievedProfessor.Salary = professor.Salary;
            retrievedProfessor.IsPhd = professor.IsPhd;

            _collegeDbContext.SaveChanges();

            return professor;
        }


        public bool DeleteProfessorById(Guid id)
        {
            if (!_collegeDbContext.Professors.Any(record => record.ProfessorId == id))
            {
                return false;
            }

            var retrievedProfessor = _collegeDbContext.Professors.Where(record => record.ProfessorId == id).FirstOrDefault();

            _collegeDbContext.Professors.Remove(retrievedProfessor);

            _collegeDbContext.SaveChanges();

            return true;
        }

    }

}
