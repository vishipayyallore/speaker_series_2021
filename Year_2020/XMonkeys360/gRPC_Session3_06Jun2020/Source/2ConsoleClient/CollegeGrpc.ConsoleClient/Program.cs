using ClientApps.Common.Utilities;
using College.GrpcServer.Protos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;
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
            /*
            WriteLine("\n\nCreating New Professor ...");
            while (response == "Y")
            {
                // Add New Professor
                AddProfessorRequest professorNew = GenerateNewProfessor();

                var newlyAddedProfessor = await Client.AddProfessorAsync(professorNew);
                WriteLine($"\n\nNew Professor Added with Professor Id: {newlyAddedProfessor.ProfessorId}");

                WriteLine("\n\nDo you want to create New Professor: {Y/N}");
                response = ReadKey().KeyChar.ToString().ToUpper();
            }
            */

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

        private static AddProfessorRequest GenerateNewProfessor()
        {
            return new AddProfessorRequest()
            {
                Name = NameGenerator.GenerateName(12),
                Doj = Timestamp.FromDateTime(DateTime.Now.AddYears(-1 * RandomNumberGenerator.GetRandomValue(1, 10)).ToUniversalTime()),
                Teaches = "CSharp, Java",
                Salary = 1234.56,
                IsPhd = true
            };
        }

        private static void DisplayProfessorDetails(GetProfessorResponse professor)
        {
            DisplayHeader();

            WriteLine($"Name: {professor.Name} \nSalary: {professor.Salary} \nTeaches: {professor.Teaches} \nDOJ: {professor.Doj}");

            DisplayFooter();
        }

    }

}
