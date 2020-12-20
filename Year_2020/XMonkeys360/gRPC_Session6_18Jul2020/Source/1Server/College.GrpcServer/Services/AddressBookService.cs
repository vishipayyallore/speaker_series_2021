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
