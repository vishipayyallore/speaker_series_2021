using Grpc.Net.Client;
using Microsoft.Extensions.Logging;
using static College.GrpcServer.Protos.AddressBookServer;

namespace CollegeGrpc.WorkerServiceClient
{

    public class AddressServiceClientHelper
    {
        static private AddressBookServerClient _client;

        static public AddressBookServerClient GetAddressBookServerClient(string serviceUrl, ILoggerFactory loggerFactory)
        {
            if (_client == null)
            {
                var channel = GrpcChannel.ForAddress(serviceUrl,
                    new GrpcChannelOptions { LoggerFactory = loggerFactory });
                _client = new AddressBookServerClient(channel);
            }

            return _client;
        }

    }

}
