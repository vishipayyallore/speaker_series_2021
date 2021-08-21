using College.Core.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace College.Web.Services
{

    public class ProfessorsDataService : IProfessorsDataService
    {
        private readonly HttpClient _httpClient;
        const string professorsEndPoint = "api/professors";

        public ProfessorsDataService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<IEnumerable<Professor>> GetAllProfessors()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Professor>>($"{professorsEndPoint}");
        }
    }

}
