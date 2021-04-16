using BlazorWasm.WebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorWasm.WebApp.Services
{

    public interface ICodeChangesService
    {
        Task<IEnumerable<CodeChangesEntity>> GetAllGitHubCodeChanges();
    }

}
