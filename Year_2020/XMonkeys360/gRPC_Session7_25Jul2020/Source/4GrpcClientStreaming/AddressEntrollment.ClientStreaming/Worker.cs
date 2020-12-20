using ClientApps.Common.Constants;
using ClientApps.Common.Utilities;
using College.GrpcServer.Protos;
using CollegeGrpc.ConsoleClient.gRPCHelpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

using static College.GrpcServer.Protos.AddressBookServer;
using static System.Console;

namespace AddressEntrollment.ClientStreaming
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _config;
        private readonly AddressBookServerClient _addressClient;

        public Worker(ILogger<Worker> logger, IConfiguration config)
        {
            _logger = logger;

            _config = config;

            _addressClient = AddressServiceClientHelper.GetAddressBookServerClient(_config["RPCService:ServiceUrl"]);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                // Address Enrollments Client Side Stream
                var userAddress = new AddAddressRequest
                {
                    StudentId = Guid.NewGuid().ToString(), /* To Be replaced with Students's Id*/
                    Name = NameGenerator.GenerateName(12),
                    FullAddress = AddressGenerator.GenerateAddress(),
                    Enrollment = Konstants.AddressConstants.EnrollmentTypes[RandomNumberGenerator.GetRandomValue(1, 4)]
                };

                using (var stream = _addressClient.AddAddressEnrollments())
                {
                    foreach (string enrollmentType in Konstants.AddressConstants.EnrollmentTypes)
                    {
                        userAddress.Enrollment = enrollmentType;
                        await stream.RequestStream.WriteAsync(userAddress);
                    }

                    await stream.RequestStream.CompleteAsync();

                    await stream;
                    WriteLine($"Sent All");
                }

                // await Task.Delay(1000, stoppingToken);
                await Task.Delay(_config.GetValue<int>("RPCService:DelayInterval"), stoppingToken);
            }
        }
    }
}
