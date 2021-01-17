using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using System.Threading.Tasks;

namespace WebAPIgRPC.BenchmarkDemo
{
    [SimpleJob(RunStrategy.ColdStart, launchCount: 10)]
    public class BenchmarkWebAPIAndgRPC
    {

        [Params(10, 20)]
        public int IterationCount;

        readonly WebAPIClient restClient = new WebAPIClient();
        // readonly GRPCClient grpcClient = new GRPCClient();

        [Benchmark]
        public async Task ApiGetAllProfessorsAsync()
        {
            await restClient.GetAllProfessorsAsync().ConfigureAwait(false);
        }


    }
}
