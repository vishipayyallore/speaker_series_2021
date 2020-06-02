using College.Api.Entities;
using College.Api.Persistence;

namespace College.Api.BLL
{
    public class ProfessorsBll
    {
        private readonly ProfessorsDal _professorsData;

        public ProfessorsBll(ProfessorsDal professorsData)
        {
            _professorsData = professorsData;
        }

        public Professor AddProfessor(Professor professor)
        {
            return _professorsData.AddProfessor(professor);
        }

    }

}
