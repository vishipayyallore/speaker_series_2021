using College.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace College.ApplicationCore.Interfaces
{

    public interface IProfessorDAL
    {
        Task<Professor> AddProfessor(Professor professor);

        Task<IEnumerable<Professor>> GetAllProfessors();

        Task<Professor> GetProfessorById(Guid professorId);
    }

}
