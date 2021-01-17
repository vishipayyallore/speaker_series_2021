using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using System.Threading.Tasks;

namespace WebAPIgRPC.BenchmarkDemo
{
    [SimpleJob(RunStrategy.ColdStart, launchCount: 2)]
    public class BenchmarkWebAPIAndgRPC
    {

        [Params(1, 2)]
        public int IterationCount;

        readonly WebAPIClient restClient = new WebAPIClient();
        readonly GrpcClient grpcClient = new GrpcClient();

        [Benchmark]
        public async Task GrpcGetAllProfessorsAsync()
        {
            await grpcClient.GetAllProfessorsAsync().ConfigureAwait(false);
        }

        [Benchmark]
        public async Task ApiGetAllProfessorsAsync()
        {
            await restClient.GetAllProfessorsAsync().ConfigureAwait(false);
        }

    }

}
