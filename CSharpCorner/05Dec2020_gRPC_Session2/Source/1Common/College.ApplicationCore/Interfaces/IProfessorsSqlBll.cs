using College.ApplicationCore.Entities;

namespace College.ApplicationCore.Interfaces
{

    public interface IProfessorsSqlBll
    {
        System.Threading.Tasks.Task<Professor> AddProfessor(Professor professor);
    }

}