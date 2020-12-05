using ClientApps.Common.Utilities;
using College.GrpcServer.Protos;
using Google.Protobuf.WellKnownTypes;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

using static System.Console;

namespace CollegeGrpc.ConsoleClient
{
    class Program
    {
        private static IConfiguration _config;
        private static string _header = "======================================================================";
        private static string _footer = "----------------------------------------------------------------------";

        static async Task Main(string[] args)
        {
            _config = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json").Build();

            var _client = CollegeServiceClientHelper.GetCollegeServiceClient(_config["RPCService:ServiceUrl"]);

            /*
            DisplayHeader("Creating New Professor ...");
            NewProfessorRequest professorNew = GenerateNewProfessor();
            var newlyAddedProfessor = await _client.AddProfessorAsync(professorNew);
            WriteLine($"\n\nNew Professor Added with Professor Id: {newlyAddedProfessor.ProfessorId}");
            DisplayFooter();
            */

            //DisplayHeader("Retrieve Single Row ...");
            //WriteLine("\n\nPlease enter a Professor Id: ");
            //var professorId = ReadLine();

            //var professorRequest = new GetProfessorRequest { ProfessorId = professorId };
            //var professor = await _client.GetProfessorByIdAsync(professorRequest);

            //DisplayProfessorDetails(professor);
            //DisplayFooter();

            DisplayHeader("Retrieve All Rows ...");
            var professors = await _client.GetAllProfessorsAsync(new Empty());

            foreach (var prof in professors.Professors)
            {
                DisplayProfessorDetails(prof);
            }

            WriteLine("\n\nThank You for using the application. \n\nPress any key ...");
            ReadKey();
        }

        // ******************** Private Methods ********************
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

        private static void DisplayFooter()
        {
            WriteLine($"\n{_footer}\n");
        }

        private static void DisplayHeader(string headerTitle)
        {
            WriteLine($"\n\n{_header}");
            WriteLine(headerTitle.PadLeft(25));
            WriteLine(_header);
        }

        private static void DisplayProfessorDetails(GetProfessorResponse professor)
        {
            DisplayHeader("Professor Details");

            WriteLine($"Name: {professor.Name} \nSalary: {professor.Salary} \nTeaches: {professor.Teaches} \nDOJ: {professor.Doj}");

            DisplayFooter();
        }
        // ******************** Private Methods ********************

    }
}
