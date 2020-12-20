using College.GrpcServer;
using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.IO;
using System.Threading.Tasks;
using static College.GrpcServer.Greeter;
using static System.Console;

namespace CollegeGrpc.ConsoleClient
{
    class Program
    {

        static private GreeterClient _client;
        
        private static IConfiguration _config;

        static protected GreeterClient Client
        {
            get
            {
                if (_client == null)
                {
                    var channel = GrpcChannel.ForAddress(_config["RPCService:ServiceUrl"]);
                    _client = new GreeterClient(channel);
                }
                return _client;
            }
        }


        static async Task Main(string[] args)
        {
            var externalFilePath = @"D:\LordKrishna\GitHub\UserSecrets\secrets.json";

            _config = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json")
                            .AddJsonFile(externalFilePath)
                            .Build();

            var jwtToken = new JwtAccessToken();
            if(jwtToken.Expiration < DateTime.Now)
            {
                jwtToken = GetTokenFromAuth0();
            }

            var headers = new Metadata
            {
                { "Authorization", $"Bearer {jwtToken.Access_Token}" }
            };

            var reply = await Client.SayHelloAsync(new HelloRequest { Name = "GreeterClient" }, headers: headers);
            WriteLine("Greeting: " + reply.Message);

            WriteLine("\n\nThank You for using the application. \n\nPress any key ...");
            ReadKey();
        }

        private static JwtAccessToken GetTokenFromAuth0()
        {
            var client = new RestClient("https://vishipayyallore.us.auth0.com");
            var request = new RestRequest("/oauth/token", Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");

            request.AddParameter("client_id", _config["Auth0Credentials:client_id"], ParameterType.GetOrPost);
            request.AddParameter("client_secret", _config["Auth0Credentials:client_secret"], ParameterType.GetOrPost);
            request.AddParameter("grant_type", _config["Auth0Credentials:grant_type"], ParameterType.GetOrPost);
            request.AddParameter("audience", _config["Auth0Credentials:Audience"], ParameterType.GetOrPost);

            var response = client.Execute(request);
            var jsonToken = JsonConvert.DeserializeObject<JwtAccessToken>(response.Content);
            jsonToken.Expiration = DateTime.Now.AddSeconds(jsonToken.Expires_In);

            return jsonToken;
        }

    }

}
