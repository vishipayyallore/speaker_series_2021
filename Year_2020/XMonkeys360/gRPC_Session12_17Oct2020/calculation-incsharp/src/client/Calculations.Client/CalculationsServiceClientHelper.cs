using Grpc.Net.Client;
using static Calculations.Server.Protos.CalculationService;

namespace Calculations.Client
{

    public class CalculationsServiceClientHelper
    {

        static private CalculationServiceClient _client;

        static public CalculationServiceClient GetCalculationServiceClient(string serviceUrl)
        {
            if (_client == null)
            {
                var channel = GrpcChannel.ForAddress(serviceUrl);
                _client = new CalculationServiceClient(channel);
            }

            return _client;
        }

    }

}
