using College.WebApi.Entities;
using College.WebApi.Persistence;
using System;
using System.Collections.Generic;

namespace College.WebApi.BAL
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


    }

}
