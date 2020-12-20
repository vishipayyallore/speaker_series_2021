using College.ApplicationCore.Entities;
using System;
using System.Collections.Generic;

namespace College.ApplicationCore.Interfaces
{

    public interface IProfessorDAL
    {
        IEnumerable<Professor> GetAllProfessors();

        Professor GetProfessorById(Guid professorId);
    }

}
