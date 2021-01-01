using College.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace College.Core.Interfaces
{

    public interface IProfessorsBLL
    {
        Task<IEnumerable<Professor>> GetAllProfessors();

        Task<Professor> GetProfessorById(Guid professorId);
    }

}
