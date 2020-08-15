using Grpc.Net.Client;
using System.Net.Http;
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
                var httpHandler = new HttpClientHandler();
                httpHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
                var httpClient = new HttpClient(httpHandler);

                var channel = GrpcChannel.ForAddress(serviceUrl, new GrpcChannelOptions { HttpClient = httpClient });
                _client = new AddressBookServerClient(channel);
            }

            return _client;
        }

    }

}
