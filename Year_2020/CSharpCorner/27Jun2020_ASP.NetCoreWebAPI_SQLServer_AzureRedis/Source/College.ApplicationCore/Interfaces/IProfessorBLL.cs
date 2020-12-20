using College.ApplicationCore.Entities;
using System;
using System.Collections.Generic;

namespace College.ApplicationCore.Interfaces
{

    public interface IProfessorBLL
    {
        IEnumerable<Professor> GetAllProfessors();

        Professor GetProfessorById(Guid professorId);
    }

}
