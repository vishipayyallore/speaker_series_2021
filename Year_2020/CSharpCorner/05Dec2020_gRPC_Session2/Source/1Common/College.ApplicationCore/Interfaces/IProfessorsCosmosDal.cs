using College.ApplicationCore.Entities;
using System.Threading.Tasks;

namespace College.ApplicationCore.Interfaces
{

    public interface IProfessorsCosmosDal
    {
        Task<Professor> AddProfessor(Professor professor);
    }

}