using AutoMapper;
using ClientApps.Common.Utilities;
using College.ApplicationCore.Entities;
using College.ApplicationCore.Interfaces;
using College.Core.Constants;
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
        private readonly IMapper _mapper;

        public AddressBookService(IAddressBLL addressBll, ILogger<AddressBookService> logger, 
            IMapper mapper)
        {
            _addressBll = addressBll ?? throw new ArgumentNullException(nameof(addressBll));

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public override async Task<AddAddressResponse> AddAddress(AddAddressRequest request, ServerCallContext context)
        {
            _logger.Log(LogLevel.Debug, "Request Received for AddressBookService::AddAddress");

            var addAddressResponse = new AddAddressResponse
            {
                Message = "success"
            };

            var address = _mapper.Map<Address>(request);

            var newAddress = await _addressBll.AddAddress(address);

            addAddressResponse.Id = newAddress.Id.ToString();

            _logger.Log(LogLevel.Debug, "Returning the results from AddressBookService::AddProfessor");

            return addAddressResponse;
        }

        public override async Task<Empty> AddAddressEnrollments(IAsyncStreamReader<AddAddressRequest> requestStream, 
            ServerCallContext context)
        {
            var dbTask = Task.Run(async () =>
            {
                await foreach (var address in requestStream.ReadAllAsync().ConfigureAwait(false))
                {
                    var _address = _mapper.Map<Address>(address);
                    _address.EnrollmentStatus = Constants.AddressConstants.EnrollmentStatus[RandomNumberGenerator.GetRandomValue(1, 4)];

                    var newAddress = await _addressBll.AddAddress(_address).ConfigureAwait(false);
                    Console.WriteLine($"Id: {newAddress.Id}");
                }
            });

            await dbTask.ConfigureAwait(false);

            return await Task.FromResult(new Empty());
        }
    }


}
