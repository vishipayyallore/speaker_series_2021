using BlazorWasm.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorWasm.WebApp.Services
{
    public class CodeChangesService : ICodeChangesService
    {
        private readonly HttpClient _httpClient;

        public CodeChangesService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<IEnumerable<CodeChangesEntity>> GetAllGitHubCodeChanges()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<CodeChangesEntity>>("");
        }

    }

}
