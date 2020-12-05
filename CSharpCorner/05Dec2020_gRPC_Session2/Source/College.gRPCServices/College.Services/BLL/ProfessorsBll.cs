using College.Api.Entities;
using College.Api.Persistence;
using System.Threading.Tasks;

namespace College.Api.BLL
{
    public class ProfessorsBll
    {
        private readonly ProfessorsDal _professorsData;

        public ProfessorsBll(ProfessorsDal professorsData)
        {
            _professorsData = professorsData;
        }

        public async Task<Professor> AddProfessor(Professor professor)
        {
            return await _professorsData.AddProfessor(professor);
        }

    }

}
