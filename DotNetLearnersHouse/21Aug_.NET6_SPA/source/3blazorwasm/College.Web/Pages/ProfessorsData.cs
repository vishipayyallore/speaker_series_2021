using College.Core.Entities;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace College.Web.Pages
{

    public partial class ProfessorsData
    {
        [Inject]
        private HttpClient _httpClient { get; set; }
        const string professorsEndPoint = "https://localhost:5001/api/professors";

        public IEnumerable<Professor> Professors { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Professors = await JsonSerializer.DeserializeAsync<IEnumerable<Professor>>
                    (await _httpClient.GetStreamAsync($"{professorsEndPoint}"),
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }

}
