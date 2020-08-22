using College.ApplicationCore.Entities;
using System;
using System.Collections.Generic;

namespace College.ApplicationCore.Interfaces
{

    public interface IProfessorBLL
    {
        Professor AddProfessor(Professor professor);

        IEnumerable<Professor> GetAllProfessors();

        Professor GetProfessorById(Guid professorId);
    }

}
