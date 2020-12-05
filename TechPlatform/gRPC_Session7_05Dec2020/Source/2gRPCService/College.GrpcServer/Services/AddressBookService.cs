using ClientApps.Common.Utilities;
using College.ApplicationCore.Entities;
using College.ApplicationCore.Interfaces;
using College.Core.Constants;
using College.GrpcServer.Protos;
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

            if (request.Enrollment == "Library Usage")
            {
                var trailers = new Metadata()
                    {
                        { "Field", "Enrollment" },
                        { "Message", "Bank enrollment is stopped temporarily" }
                    };

                throw new RpcException(new Status(StatusCode.PermissionDenied, "Library Usage enrollment is stopped temporarily"), trailers);
            }

            // TODO: Technical Debt
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

    }


}
