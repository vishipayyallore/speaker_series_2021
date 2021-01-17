using BenchmarkDotNet.Running;
using static System.Console;

namespace WebAPIgRPC.BenchmarkDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run();

            //GrpcClient grpcClient = new GrpcClient();
            //var output = await grpcClient.GetAllProfessorsAsync().ConfigureAwait(false);
            //WriteLine($"Output: {output}");

            WriteLine("\n\nPress any key ....");
            ReadKey();
        }
    }
}
