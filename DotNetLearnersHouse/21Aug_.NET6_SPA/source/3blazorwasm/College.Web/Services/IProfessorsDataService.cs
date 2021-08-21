using College.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace College.Web.Services
{
    public interface IProfessorsDataService
    {
        Task<IEnumerable<Professor>> GetAllProfessors();
    }
}