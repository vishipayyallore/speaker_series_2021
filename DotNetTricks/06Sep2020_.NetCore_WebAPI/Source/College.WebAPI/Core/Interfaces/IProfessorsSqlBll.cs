using College.WebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace College.WebAPI.Interfaces
{

    public interface IProfessorsSqlBll
    {
        Task<IEnumerable<Professor>> GetAllProfessors();

        Task<Professor> GetProfessorById(Guid professorId);

        Task<Professor> AddProfessor(Professor professor);

        Task<Professor> UpdateProfessor(Professor professor);

        Task<bool> DeleteProfessorById(Guid id);
    }

}
