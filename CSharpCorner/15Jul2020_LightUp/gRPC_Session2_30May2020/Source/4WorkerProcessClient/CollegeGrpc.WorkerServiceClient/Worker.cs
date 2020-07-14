using ClientApps.Common.Utilities;
using ClientApps.Common.Constants;
using College.GrpcServer.Protos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using static College.GrpcServer.Protos.AddressBookServer;

namespace CollegeGrpc.WorkerServiceClient
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _config;
        private readonly AddressBookServerClient _client;

        public Worker(ILogger<Worker> logger, IConfiguration config)
        {
            _logger = logger;

            _config = config;

            _client = AddressServiceClientHelper.GetAddressBookServerClient(_config["RPCService:ServiceUrl"]);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                var userAddress = new AddAddressRequest
                {
                    StudentId = Guid.NewGuid().ToString(), /* To Be replaced with Students's Id*/
                    Name = NameGenerator.GenerateName(12),
                    FullAddress = AddressGenerator.GenerateAddress(),
                    Enrollment = Konstants.AddressConstants.EnrollmentTypes[RandomNumberGenerator.GetRandomValue(1, 4)]
                };

                var newAddress = await _client.AddAddressAsync(userAddress);

                Console.WriteLine($"Address Data with Id: {newAddress.Id}");

                await Task.Delay(_config.GetValue<int>("RPCService:DelayInterval"), stoppingToken);
            }
        }
    }
}
