using ClientApps.Common.Utilities;
using College.GrpcServer.Protos;
using CollegeGrpc.ConsoleClient.Helpers;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
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

            //**************** ADDRESS BOOK CLIENT SIDE STREAMING ****************//
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
            //**************** ADDRESS BOOK CLIENT SIDE STREAMING ****************//

            //**************** ADDRESS BOOK SERVER SIDE STREAMING ****************//
            var studentEnrollmentsRequest = new AddressEnrollmentRequest 
            { 
                StudentId = "62b76fc7-46d9-4d1c-a246-7f4083a87634"
            };

            using var studentEnrollments = _addressClient
                                                .RetrieveAddressEnrollments(studentEnrollmentsRequest);
            try
            {
                await foreach (var studentEnrollment in studentEnrollments.ResponseStream.ReadAllAsync())
                {
                    WriteLine($"{studentEnrollment.StudentId} | {studentEnrollment.Name} | {studentEnrollment.Enrollment} | {studentEnrollment.EnrollmentStatus}");
                }
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Cancelled)
            {
                Console.WriteLine("Stream cancelled.");
            }
            //**************** ADDRESS BOOK SERVER SIDE STREAMING ****************//

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
