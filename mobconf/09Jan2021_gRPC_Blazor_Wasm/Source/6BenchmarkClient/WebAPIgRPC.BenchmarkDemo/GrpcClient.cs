using College.GrpcServer.Protos;
using Google.Protobuf.WellKnownTypes;
using System.Threading.Tasks;
using static College.GrpcServer.Protos.CollegeSvc;

namespace WebAPIgRPC.BenchmarkDemo
{

    public class GrpcClient
    {
        private readonly CollegeSvcClient _client = CollegeServiceClientHelper.GetCollegeServiceClient("https://localhost:5001");

        public async Task<AllProfessorsResonse> GetAllProfessorsAsync()
        {
            var professors = await _client.GetAllProfessorsAsync(new Empty());

            return professors;
        }

    }
}
