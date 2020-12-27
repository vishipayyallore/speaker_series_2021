using College.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace College.ApplicationCore.Interfaces
{

    public interface IProfessorsSqlBll
    {
        Task<Professor> AddProfessor(Professor professor);

        Task<Professor> GetProfessorById(Guid professorId);

        Task<IEnumerable<Professor>> GetAllProfessors();

        Task<Professor> UpdateProfessor(Professor professor);

        Task<bool> DeleteProfessorById(Guid professorId);
    }

}