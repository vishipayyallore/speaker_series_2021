using College.WebAPI.Core.Entities;
using College.WebAPI.DAL;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace College.WebAPI.BLL
{

    public class ProfessorsSqlBll
    {
        private readonly ProfessorsSqlDal _professorsSqlDal;
        private readonly ILogger<ProfessorsSqlBll> _logger;

        public ProfessorsSqlBll(ProfessorsSqlDal professorsSqlDal, ILogger<ProfessorsSqlBll> logger)
        {
            _professorsSqlDal = professorsSqlDal ?? throw new ArgumentNullException(nameof(professorsSqlDal));
            
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Professor> AddProfessor(Professor professor)
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsSqlBll::AddProfessor");

            var newProfessor = await _professorsSqlDal.AddProfessor(professor)
                                        .ConfigureAwait(false);

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsSqlBll::AddProfessor");

            return newProfessor;
        }

        public async Task<IEnumerable<Professor>> GetAllProfessors()
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsSqlBll::GetAllProfessors");

            var allProfessors = await _professorsSqlDal.GetAllProfessors()
                                        .ConfigureAwait(false);

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsSqlBll::GetAllProfessors");

            return allProfessors;
        }

        public async Task<Professor> GetProfessorById(Guid professorId)
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsSqlBll::GetProfessorById");

            var professor = await _professorsSqlDal.GetProfessorById(professorId)
                                    .ConfigureAwait(false);

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsSqlBll::GetProfessorById");

            return professor;
        }

        public async Task<Professor> UpdateProfessor(Professor professor)
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsSqlBll::UpdateProfessor");

            var updatedProfessor = await _professorsSqlDal.UpdateProfessor(professor)
                                            .ConfigureAwait(false);

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsSqlBll::UpdateProfessor");

            return updatedProfessor;
        }

        public async Task<bool> DeleteProfessorById(Guid professorId)
        {
            _logger.Log(LogLevel.Debug, "Request Received for ProfessorsSqlBll::DeleteProfessorById");

            var professorDeleted = await _professorsSqlDal.DeleteProfessorById(professorId)
                                                            .ConfigureAwait(false);

            _logger.Log(LogLevel.Debug, "Returning the results from ProfessorsSqlBll::DeleteProfessorById");

            return professorDeleted;
        }

    }

}
