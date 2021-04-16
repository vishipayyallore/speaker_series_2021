using BlazorWasm.WebApp.Models;
using BlazorWasm.WebApp.Services;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorWasm.WebApp.Pages
{

    public partial class GitHubCodeChanges
    {
        [Inject]
        private ICodeChangesService codeChangesService { get; set; }

        IEnumerable<CodeChangesEntity> codeChangesEntities;

        protected override async Task OnInitializedAsync()
        {
            codeChangesEntities = await codeChangesService
                                            .GetAllGitHubCodeChanges()
                                            .ConfigureAwait(false);
        }
    }

}
