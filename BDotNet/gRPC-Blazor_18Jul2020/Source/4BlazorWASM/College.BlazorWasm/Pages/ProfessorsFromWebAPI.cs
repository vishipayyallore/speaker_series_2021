using College.Core.Entities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace College.BlazorWasm.Pages
{
    public partial class ProfessorsFromWebAPI
    {
        [Inject]
        private HttpClient Http { get; set; }

        public IEnumerable<Professor> Professors { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Professors = await JsonSerializer.DeserializeAsync<IEnumerable<Professor>>
                    (await Http.GetStreamAsync($"https://localhost:5002/api/professors"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
