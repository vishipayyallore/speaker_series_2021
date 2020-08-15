using Grpc.Net.Client;
using System.Net.Http;
using static College.GrpcServer.Protos.CollegeService;

namespace CollegeGrpc.WebApiClient.Helpers
{

    public class CollegeServiceClientHelper
    {
        static private CollegeServiceClient _client;

        public static CollegeServiceClient GetCollegeServiceClient(string serviceUrl)
        {
            if (_client == null)
            {
                var httpHandler = new HttpClientHandler();
                httpHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
                var httpClient = new HttpClient(httpHandler);

                var channel = GrpcChannel.ForAddress(serviceUrl, new GrpcChannelOptions { HttpClient = httpClient });
                _client = new CollegeServiceClient(channel);
            }

            return _client;
        }

    }

}
