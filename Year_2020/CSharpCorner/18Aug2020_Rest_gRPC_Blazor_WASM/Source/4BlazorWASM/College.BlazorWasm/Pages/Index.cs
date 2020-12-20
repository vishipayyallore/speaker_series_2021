using College.GrpcServer;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace College.BlazorWasm.Pages
{
    public partial class Index
    {
        public string ResponseFromGrpc;

        [Inject]
        public GrpcChannel Channel { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var client = new Greeter.GreeterClient(Channel);
            ResponseFromGrpc = (await client.SayHelloAsync(new HelloRequest { Name = ".NET" })).Message;
        }
    }
}
