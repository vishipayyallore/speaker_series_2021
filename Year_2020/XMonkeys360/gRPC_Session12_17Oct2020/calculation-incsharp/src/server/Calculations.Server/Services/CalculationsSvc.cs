using Calculations.Server.Protos;
using Grpc.Core;
using System.Threading.Tasks;

using static Calculations.Server.Protos.CalculationService;
using static System.Console;

namespace Calculations.Server.Services
{

    public class CalculationsSvc : CalculationServiceBase
    {

        public CalculationsSvc()
        {
        }

        public override Task<AddResponse> AddNumbers(AddRequest request, ServerCallContext context)
        {
            WriteLine($"AddNumbers request received with values {request.Value1} {request.Value2}");

            var addResponse = new AddResponse { Sum = (request.Value1 + request.Value2) };

            WriteLine($"Sending the Response {addResponse.Sum}");

            return Task.FromResult(addResponse);
        }

    }

}
