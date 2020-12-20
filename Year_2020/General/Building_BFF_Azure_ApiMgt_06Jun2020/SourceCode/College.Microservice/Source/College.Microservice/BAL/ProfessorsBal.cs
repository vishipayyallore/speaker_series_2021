using College.Microservice.Entities;
using College.Services.Persistence;
using System;
using System.Collections.Generic;

namespace College.Microservice.BAL
{
    public class ProfessorsBal
    {
        private readonly ProfessorsDal _professorsData;

        public ProfessorsBal(ProfessorsDal professorsData)
        {
            _professorsData = professorsData;
        }

        public IEnumerable<Professor> GetProfessors()
        {
            return _professorsData.GetProfessors();
        }

        public Professor GetProfessorById(Guid id)
        {
            return _professorsData.GetProfessorById(id);
        }


        public Professor AddProfessor(Professor professor)
        {
            return _professorsData.AddProfessor(professor);
        }

        public Professor UpdateProfessor(Professor professor)
        {
            return _professorsData.UpdateProfessor(professor);
        }

        public bool DeleteProfessorById(Guid id)
        {
            return _professorsData.DeleteProfessorById(id);
        }

    }

}
