using ClientApps.Common.Constants;
using ClientApps.Common.Utilities;
using College.GrpcServer.Protos;
using CollegeGrpc.ConsoleClient.gRPCHelpers;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using static College.GrpcServer.Protos.AddressBookServer;
using static College.GrpcServer.Protos.CollegeService;

using static System.Console;

namespace CollegeGrpc.ConsoleClient
{

    class Program
    {

        // static private CollegeServiceClient _client;
        private static IConfiguration _config;
        private static string _header = "======================================================================";
        private static string _footer = "----------------------------------------------------------------------";


        static async Task Main(string[] args)
        {
            string response = "Y";
            _config = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json").Build();

            // gRPC Clients
            CollegeServiceClient CollegeClient = CollegeServiceClientHelper.GetCollegeServiceClient(_config["RPCService:ServiceUrl"]);
            AddressBookServerClient AddressClient = AddressServiceClientHelper.GetAddressBookServerClient(_config["RPCService:ServiceUrl"]);

            /*
            var cts = new CancellationTokenSource(TimeSpan.FromSeconds(50));

            using var replies = AddressClient.GetWeatherStream(new Empty(), cancellationToken: cts.Token);

            try
            {
                await foreach (var weatherData in replies.ResponseStream.ReadAllAsync(cancellationToken: cts.Token))
                {
                    Console.WriteLine($"{weatherData.DateTimeStamp.ToDateTime():s} | {weatherData.Summary} | {weatherData.TemperatureC} C");
                }
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Cancelled)
            {
                Console.WriteLine("Stream cancelled.");
            }
            */

            // Address Enrollments Client Request for Server Streaming.
            var studentEnrollmentsRequest = new AddressEnrollmentRequest { StudentId = "3698FAED-83A1-4700-89EE-CAFE7716833E" };

            using var studentEnrollments = AddressClient.RetrieveAddressEnrollments(studentEnrollmentsRequest);

            try
            {
                await foreach (var studentEnrollment in studentEnrollments.ResponseStream.ReadAllAsync())
                {
                    Console.WriteLine($"{studentEnrollment.StudentId} {studentEnrollment.Name} {studentEnrollment.Enrollment} {studentEnrollment.EnrollmentStatus}");
                }
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Cancelled)
            {
                Console.WriteLine("Stream cancelled.");
            }

            // Address Enrollments Client Side Stream
            var userAddress = new AddAddressRequest
            {
                StudentId = Guid.NewGuid().ToString(), /* To Be replaced with Students's Id*/
                Name = NameGenerator.GenerateName(12),
                FullAddress = AddressGenerator.GenerateAddress(),
                Enrollment = Konstants.AddressConstants.EnrollmentTypes[RandomNumberGenerator.GetRandomValue(1, 4)]
            };

            using (var stream = AddressClient.AddAddressEnrollments())
            {
                foreach (string enrollmentType in Konstants.AddressConstants.EnrollmentTypes)
                {
                    userAddress.Enrollment = enrollmentType;
                    await stream.RequestStream.WriteAsync(userAddress);
                }

                await stream.RequestStream.CompleteAsync();

                await stream;
                WriteLine($"Sent All");
            }


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

                var professor = await CollegeClient.GetProfessorByIdAsync(professorRequest);

                DisplayProfessorDetails(professor);

                WriteLine("\n\nDo you want to Lookup a Professor: {Y/N}");
                response = ReadKey().KeyChar.ToString().ToUpper();
            }

            // Address Service gRPC
            var userAddress1 = new AddAddressRequest
            {
                StudentId = Guid.NewGuid().ToString(), /* To Be replaced with Students's Id*/
                Name = NameGenerator.GenerateName(12),
                FullAddress = AddressGenerator.GenerateAddress(),
                Enrollment = Konstants.AddressConstants.EnrollmentTypes[RandomNumberGenerator.GetRandomValue(1, 4)]
            };


            var newAddress = await AddressClient.AddAddressAsync(userAddress1);

            WriteLine($"Address Data with Id: {newAddress.Id}");

            /*
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
            */

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
                Teaches = "CSharp, Java, GoLang",
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


//static protected CollegeServiceClient Client
//{
//    get
//    {
//        var loggerFactory = LoggerFactory.Create(logging =>
//        {
//            logging.AddConsole();
//            logging.SetMinimumLevel(LogLevel.Debug);
//        });


//        if (_client == null)
//        {
//            var channel = GrpcChannel.ForAddress(_config["RPCService:ServiceUrl"],
//                new GrpcChannelOptions { LoggerFactory = loggerFactory });
//            _client = new CollegeServiceClient(channel);
//        }
//        return _client;
//    }
//}
