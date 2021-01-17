using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WebAPIgRPC.BenchmarkDemo
{

    public class WebAPIClient
    {

        private static readonly HttpClient _client = new HttpClient();

        public async Task<string> GetAllProfessorsAsync()
        {
            string professors = string.Empty;

            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                HttpResponseMessage response = await _client
                                                        .GetAsync("https://localhost:5002/api/v1/professors")
                                                        .ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    professors = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                }

            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }

            return professors;
        }

    }

}
