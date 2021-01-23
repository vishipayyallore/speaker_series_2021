using Grpc.Net.Client;
using static College.GrpcServer.Protos.CollegeSvc;

namespace CollegeGrpc.ConsoleClient
{

    public class CollegeServiceClientHelper
    {
        static private CollegeSvcClient _client;

        static public CollegeSvcClient GetCollegeServiceClient(string serviceUrl)
        {
            if (_client == null)
            {
                var channel = GrpcChannel.ForAddress(serviceUrl);
                _client = new CollegeSvcClient(channel);
            }

            return _client;
        }

    }

}
