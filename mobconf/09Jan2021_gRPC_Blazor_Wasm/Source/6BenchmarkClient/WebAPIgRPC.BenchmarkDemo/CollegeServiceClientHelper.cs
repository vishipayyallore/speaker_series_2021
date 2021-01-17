using Grpc.Net.Client;
using static College.GrpcServer.Protos.CollegeSvc;

namespace WebAPIgRPC.BenchmarkDemo
{

    public class CollegeServiceClientHelper
    {
        static private CollegeSvcClient _client;

        static public CollegeSvcClient GetCollegeServiceClient(string serviceUrl)
        {
            if (_client == null)
            {
                var channel = GrpcChannel.ForAddress(serviceUrl, new GrpcChannelOptions
                {
                    MaxReceiveMessageSize = 20 * 1024 * 1024, // 5 MB
                    MaxSendMessageSize = 20 * 1024 * 1024 // 2 MB
                });
                _client = new CollegeSvcClient(channel);
            }

            return _client;
        }

    }

}
