using College.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace College.Core.Interfaces
{

    public interface IProfessorsSqlDal
    {
        Task<IEnumerable<Professor>> GetAllProfessors();
    }

}
