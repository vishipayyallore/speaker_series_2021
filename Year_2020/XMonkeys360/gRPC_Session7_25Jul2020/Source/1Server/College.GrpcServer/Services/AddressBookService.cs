using ClientApps.Common.Utilities;
using College.ApplicationCore.Constants;
using College.ApplicationCore.Entities;
using College.ApplicationCore.Interfaces;
using College.GrpcServer.Protos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using static College.GrpcServer.Protos.AddressBookServer;

namespace College.GrpcServer.Services
{

    public class AddressBookService : AddressBookServerBase
    {
        private readonly IAddressBLL _addressBll;
        private readonly ILogger<AddressBookService> _logger;

        private static readonly string[] Summaries =
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public AddressBookService(IAddressBLL addressBll, ILogger<AddressBookService> logger)
        {
            _addressBll = addressBll;

            _logger = logger;
        }

        public override async Task<AddAddressResponse> AddAddress(AddAddressRequest request, ServerCallContext context)
        {
            _logger.Log(LogLevel.Debug, "Request Received for AddressBookService::AddAddress");

            var addAddressResponse = new AddAddressResponse
            {
                Message = "success"
            };

            var address = new Address
            {
                StudentId = Guid.Parse(request.StudentId),
                Name = request.Name,
                FullAddress = request.FullAddress,
                Enrollment = request.Enrollment,
                EnrollmentStatus = Constants.AddressConstants.EnrollmentStatus[RandomNumberGenerator.GetRandomValue(1, 4)]
            };

            var newAddress = await _addressBll.AddAddress(address);

            addAddressResponse.Id = newAddress.Id.ToString();

            _logger.Log(LogLevel.Debug, "Returning the results from AddressBookService::AddProfessor");

            return addAddressResponse;
        }


        public override async Task GetWeatherStream(Empty request, IServerStreamWriter<WeatherData> responseStream, ServerCallContext context)
        {
            var rng = new Random();
            var now = DateTime.UtcNow;

            var i = 0;
            while (!context.CancellationToken.IsCancellationRequested && i < 20)
            {
                await Task.Delay(500); // Gotta look busy

                var forecast = new WeatherData
                {
                    DateTimeStamp = Timestamp.FromDateTime(now.AddDays(i++)),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                };

                _logger.LogInformation("Sending WeatherData response");

                await responseStream.WriteAsync(forecast);
            }
        }

        public override async Task<Empty> AddAddressEnrollments(IAsyncStreamReader<AddAddressRequest> requestStream, ServerCallContext context)
        {
            var dbTask = Task.Run(async () =>
            {
                await foreach (var address in requestStream.ReadAllAsync())
                {
                    var _address = new Address
                    {
                        StudentId = Guid.Parse(address.StudentId),
                        Name = address.Name,
                        FullAddress = address.FullAddress,
                        Enrollment = address.Enrollment,
                        EnrollmentStatus = Constants.AddressConstants.EnrollmentStatus[RandomNumberGenerator.GetRandomValue(1, 4)]
                    };

                    var newAddress = await _addressBll.AddAddress(_address);
                    Console.WriteLine($"Id: {newAddress.Id}");
                }
            });

            await dbTask.ConfigureAwait(false);

            return await Task.FromResult(new Empty());
        }

        public override async Task RetrieveAddressEnrollments(AddressEnrollmentRequest request, IServerStreamWriter<AddressEnrollmentResponse> responseStream, ServerCallContext context)
        {
            var studentEnrollments = await _addressBll.RetrieveAddressEnrollments(Guid.Parse(request.StudentId));

            foreach (var enrollment in studentEnrollments)
            {
                Console.WriteLine($"{enrollment.Enrollment} {enrollment.EnrollmentStatus}");

                var addressEnrollment = new AddressEnrollmentResponse
                {
                    StudentId = enrollment.StudentId.ToString(),
                    Name = enrollment.Name,
                    FullAddress = enrollment.FullAddress,
                    Enrollment = enrollment.Enrollment,
                    EnrollmentStatus = enrollment.EnrollmentStatus
                };

                await responseStream.WriteAsync(addressEnrollment);
            }
        }

        //public override Task RetrieveAddressEnrollments(AddressEnrollmentRequest request, IServerStreamWriter<AddressEnrollmentResponse> responseStream, ServerCallContext context)
        //{
        //    var studentEnrollments = await _addressBll.RetrieveAddressEnrollments(Guid.Parse(request.StudentId));

        //    foreach (var enrollment in studentEnrollments)
        //    {
        //        Console.WriteLine($"{enrollment.Enrollment} {enrollment.EnrollmentStatus}");

        //        var addressEnrollment = new AddressEnrollmentResponse
        //        {
        //            StudentId = enrollment.StudentId.ToString(),
        //            Name = enrollment.Name,
        //            FullAddress = enrollment.FullAddress,
        //            Enrollment = enrollment.Enrollment,
        //            EnrollmentStatus = enrollment.EnrollmentStatus
        //        };

        //        await responseStream.WriteAsync(addressEnrollment);
        //    }
        //}

        /*
        private AddressData GetAddressData(AddressAdditionRequest address)
        {
            return new AddressData
            {
                Name = address.Name,
                Address = address.Address,
                Enrollment = address.Enrollment,
                EnrollmentStatus = _enrollmentStatus[Utilities.GetRandomValue(1, 4)]
            };
        }
        */

    }

}
