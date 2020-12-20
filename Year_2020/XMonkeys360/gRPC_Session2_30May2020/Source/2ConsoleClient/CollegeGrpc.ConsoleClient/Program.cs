using ClientApps.Common.Utilities;
using College.GrpcServer.Protos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;
using static College.GrpcServer.Protos.CollegeService;

using static System.Console;

namespace CollegeGrpc.ConsoleClient
{

    class Program
    {

        static private CollegeServiceClient _client;
        private static IConfiguration _config;

        static protected CollegeServiceClient Client
        {
            get
            {
                if (_client == null)
                {
                    var channel = GrpcChannel.ForAddress(_config["RPCService:ServiceUrl"]);
                    _client = new CollegeServiceClient(channel);
                }
                return _client;
            }
        }

        static async Task Main(string[] args)
        {
            string response = "Y";
            _config = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json").Build();

            WriteLine("\n\nCreating New Professor ...");
            while(response == "Y")
            {
                // Add New Professor
                NewProfessorRequest professorNew = GenerateNewProfessor();

                var newlyAddedProfessor = await Client.AddProfessorAsync(professorNew);
                WriteLine($"\n\nNew Professor Added with Professor Id: {newlyAddedProfessor.ProfessorId}");

                WriteLine("\n\nDo you want to create New Professor: {Y/N}");
                response = ReadKey().KeyChar.ToString().ToUpper();
            }

            Console.WriteLine("\n\nThank You for using the application. \n\nPress any key ...");
            Console.ReadKey();
        }

        private static NewProfessorRequest GenerateNewProfessor()
        {
            return new NewProfessorRequest()
            {
                Name = NameGenerator.GenerateName(12),
                Doj = Timestamp.FromDateTime(DateTime.Now.AddYears(-1 * RandomNumberGenerator.GetRandomValue(1, 10)).ToUniversalTime()),
                Teaches = "CSharp, Java",
                Salary = 1234.56,
                IsPhd = true
            };
        }
    }

}
