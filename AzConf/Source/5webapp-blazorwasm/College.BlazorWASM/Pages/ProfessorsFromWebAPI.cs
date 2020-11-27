using College.Core.Entities;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace College.BlazorWASM.Pages
{
    public partial class ProfessorsFromWebAPI
    {
        [Inject]
        private HttpClient Http { get; set; }

        public IEnumerable<Professor> Professors { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Professors = await JsonSerializer.DeserializeAsync<IEnumerable<Professor>>
                    (await Http.GetStreamAsync($"https://api.azurewebsites.net/api/v1/professors"), 
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
    
}
