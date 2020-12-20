using ClientApps.Common.Utilities;
using College.GrpcServer.Protos;
using CollegeGrpc.ConsoleClient.Helpers;
using Google.Protobuf.WellKnownTypes;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;
using static College.Core.Constants.Constants;
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

            var _collegeClient = CollegeServiceClientHelper.GetCollegeServiceClient(_config["RPCService:ServiceUrl"]);
            
            var _addressClient = AddressServiceClientHelper.GetAddressBookServerClient(_config["RPCService:ServiceUrl"]);

            //**************** ADDRESS BOOK ****************//
            var userAddress = new AddAddressRequest
            {
                StudentId = Guid.NewGuid().ToString(), /* To Be replaced with Students's Id*/
                Name = NameGenerator.GenerateName(12),
                FullAddress = AddressGenerator.GenerateAddress(),
                Enrollment = AddressConstants.EnrollmentTypes[RandomNumberGenerator.GetRandomValue(1, 4)]
            };

            using (var stream = _addressClient.AddAddressEnrollments())
            {
                foreach (string enrollmentType in AddressConstants.EnrollmentTypes)
                {
                    userAddress.Enrollment = enrollmentType;
                    await stream.RequestStream.WriteAsync(userAddress).ConfigureAwait(false);
                }

                await stream.RequestStream.CompleteAsync().ConfigureAwait(false);

                await stream;
                WriteLine($"Sent All");
            }
            //**************** ADDRESS BOOK ****************//

            /*
            DisplayHeader("Creating New Professor ...");
            NewProfessorRequest professorNew = GenerateNewProfessor();
            var newlyAddedProfessor = await _collegeClient.AddProfessorAsync(professorNew);
            WriteLine($"\n\nNew Professor Added with Professor Id: {newlyAddedProfessor.ProfessorId}");
            DisplayFooter();
            */

            //DisplayHeader("Retrieve Single Row ...");
            //WriteLine("\n\nPlease enter a Professor Id: ");
            //var professorId = ReadLine();

            //var professorRequest = new GetProfessorRequest { ProfessorId = professorId };
            //var professor = await _collegeClient.GetProfessorByIdAsync(professorRequest);

            //DisplayProfessorDetails(professor);
            //DisplayFooter();

            DisplayHeader("Retrieve All Rows ...");
            var professors = await _collegeClient.GetAllProfessorsAsync(new Empty());

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
