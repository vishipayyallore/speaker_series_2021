using College.Core.Entities;
using College.Web.Services;
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
        private IProfessorsDataService ProfessorsDataService { get; set; }

        public IEnumerable<Professor> Professors { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Professors = await ProfessorsDataService.GetAllProfessors();
        }
    }

}


/*
 * 
 * await JsonSerializer.DeserializeAsync<IEnumerable<Professor>>
                    (await _httpClient.GetStreamAsync($"{professorsEndPoint}"),
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
*/