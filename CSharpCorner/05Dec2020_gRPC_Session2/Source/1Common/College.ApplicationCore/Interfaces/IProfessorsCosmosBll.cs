using College.ApplicationCore.Entities;

namespace College.ApplicationCore.Interfaces
{

    public interface IProfessorsCosmosBll
    {
        System.Threading.Tasks.Task<Professor> AddProfessor(Professor professor);
    }

}