using College.Services.Protos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using System;
using System.Threading.Tasks;

using static System.Console;

namespace CollegeApi.GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new CollegeService.CollegeServiceClient(channel);

            // Add New Professor
            NewProfessorRequest professorNew = new NewProfessorRequest()
            {
                Name = "Shiva",
                Doj = Timestamp.FromDateTime(DateTime.Now.AddYears(-5).ToUniversalTime()),
                Teaches = "CSharp, Java",
                Salary = 1234.56,
                IsPhd = true
            };
            var newlyAddedProfessor = await client.AddProfessorAsync(professorNew);
            WriteLine($"New Professor Added with Professor Id: {newlyAddedProfessor.ProfessorId}");

            WriteLine("Press any key to exit...");
            ReadKey();
        }
    }
}
