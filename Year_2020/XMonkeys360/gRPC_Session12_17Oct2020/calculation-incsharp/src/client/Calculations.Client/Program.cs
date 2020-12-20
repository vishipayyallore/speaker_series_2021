using Calculations.Server.Protos;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;

using static System.Console;

namespace Calculations.Client
{
    class Program
    {
        private static IConfiguration _config;

        static async Task Main(string[] args)
        {
            _config = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json").Build();

            var _client = CalculationsServiceClientHelper.GetCalculationServiceClient(_config["RPCService:ServiceUrl"]);

            var additionRequest = new AddRequest { Value1 = 10, Value2 = 20 };

            WriteLine($"Sending Addition Request to gRPC Server .... ");
            var sumResults = await _client.AddNumbersAsync(additionRequest);
            WriteLine($"Received response for Addition Request to gRPC Server. Sum: {sumResults.Sum} ");

            WriteLine("\n\nThank You for using the application. \n\nPress any key ...");
            ReadKey();
        }

    }
}
