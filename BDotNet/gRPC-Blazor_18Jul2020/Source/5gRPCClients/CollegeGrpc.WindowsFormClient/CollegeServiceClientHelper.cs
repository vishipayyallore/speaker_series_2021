using Grpc.Net.Client;
using static College.GrpcServer.Protos.CollegeService;

namespace CollegeGrpc.WindowsFormClient
{

    public class CollegeServiceClientHelper
    {
        static private CollegeServiceClient _client;

        static public CollegeServiceClient GetCollegeServiceClient(string serviceUrl)
        {
            if (_client == null)
            {
                var channel = GrpcChannel.ForAddress(serviceUrl);
                _client = new CollegeServiceClient(channel);
            }

            return _client;
        }

    }

}
