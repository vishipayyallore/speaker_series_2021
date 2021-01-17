using BenchmarkDotNet.Running;
using static System.Console;

namespace WebAPIgRPC.BenchmarkDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run();

            WriteLine("\n\nPress any key ....");
            ReadKey();
        }
    }
}
