using College.Core.Entities;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace College.BlazorWasm.Pages
{
    public partial class ProfessorDetails
    {
        [Inject]
        private HttpClient Http { get; set; }

        [Parameter]
        public string professorId { get; set; }

        public Professor ProfessorDetail { get; set; } = new Professor();

        protected override async Task OnInitializedAsync()
        {
            ProfessorDetail = await JsonSerializer.DeserializeAsync<Professor>
                    (await Http.GetStreamAsync($"https://localhost:5001/api/v1/professors/{professorId}"),
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
