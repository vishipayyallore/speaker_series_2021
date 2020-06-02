using College.ApplicationCore.Entities;
using College.ApplicationCore.Interfaces;
using Microsoft.Extensions.Logging;

namespace College.ServerBLL
{

    public class ProfessorBLL : IProfessorBLL
    {
        private readonly IProfessorDAL _professorDal;
        private readonly ILogger<ProfessorBLL> _logger;

        public ProfessorBLL(IProfessorDAL professorDal, ILogger<ProfessorBLL> logger)
        {
            _professorDal = professorDal;

            _logger = logger;
        }

        public Professor AddProfessor(Professor professor)
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorBLL::AddProfessor");

            return _professorDal.AddProfessor(professor);
        }
    }

}
