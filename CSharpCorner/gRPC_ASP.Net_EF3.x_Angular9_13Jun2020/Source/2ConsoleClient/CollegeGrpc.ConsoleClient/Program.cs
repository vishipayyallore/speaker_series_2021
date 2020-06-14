using College.GrpcServer.Protos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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
        private static string _header = "======================================================================";
        private static string _footer = "----------------------------------------------------------------------";

        static protected CollegeServiceClient Client
        {
            get
            {
                var loggerFactory = LoggerFactory.Create(logging =>
                {
                    logging.AddConsole();
                    logging.SetMinimumLevel(LogLevel.Debug);
                });


                if (_client == null)
                {
                    var channel = GrpcChannel.ForAddress(_config["RPCService:ServiceUrl"],
                        new GrpcChannelOptions { LoggerFactory = loggerFactory });
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

            response = "Y";
            while (response == "Y")
            {
                WriteLine("\n\nPlease enter a Professor Id: ");
                var professorId = ReadLine();

                // Retrieve Single Row
                var professorRequest = new GetProfessorRequest { ProfessorId = professorId };

                var professor = await Client.GetProfessorByIdAsync(professorRequest);

                DisplayProfessorDetails(professor);

                WriteLine("\n\nDo you want to Lookup a Professor: {Y/N}");
                response = ReadKey().KeyChar.ToString().ToUpper();
            }

            response = "Y";
            while (response == "Y")
            {
                // Retrieve Multiple Rows
                var professors = await Client.GetAllProfessorsAsync(new Empty());

                foreach (var prof in professors.Professors)
                {
                    DisplayProfessorDetails(prof);
                }

                WriteLine("\n\nDo you want to retrieve all professors: {Y/N}");
                response = ReadKey().KeyChar.ToString().ToUpper();
            }

            WriteLine("\n\nThank You for using the application. \n\nPress any key ...");
            ReadKey();
        }

        private static void DisplayFooter()
        {
            WriteLine($"\n{_footer}\n");
        }

        private static void DisplayHeader()
        {
            WriteLine($"\n\n{_header}");
            WriteLine("Professor Details".PadLeft(25));
            WriteLine(_header);
        }

        private static void DisplayProfessorDetails(GetProfessorResponse professor)
        {
            DisplayHeader();

            WriteLine($"Name: {professor.Name} \nSalary: {professor.Salary} \nTeaches: {professor.Teaches} \nDOJ: {professor.Doj}");

            DisplayFooter();
        }

    }

}
