using College.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace College.ApplicationCore.Interfaces
{

    public interface IProfessorDAL
    {
        Professor AddProfessor(Professor professor);

        IEnumerable<Professor> GetAllProfessors();

        Professor GetProfessorById(Guid professorId);
    }

}
