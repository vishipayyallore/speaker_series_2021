using Grpc.Net.Client;
using static College.GrpcServer.Protos.AddressBookServer;

namespace CollegeGrpc.WorkerServiceClient
{

    public class AddressServiceClientHelper
    {
        static private AddressBookServerClient _client;

        static public AddressBookServerClient GetAddressBookServerClient(string serviceUrl)
        {
            if (_client == null)
            {
                var channel = GrpcChannel.ForAddress(serviceUrl);
                _client = new AddressBookServerClient(channel);
            }

            return _client;
        }

    }

}
