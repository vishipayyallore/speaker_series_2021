using College.ApplicationCore.Entities;
using College.ApplicationCore.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace College.ServerBLL
{

    public class AddressBLL : IAddressBLL
    {
        private readonly IAddressDAL _addressDal;
        private readonly ILogger<AddressBLL> _logger;

        public AddressBLL(IAddressDAL addressDal, ILogger<AddressBLL> logger)
        {
            _addressDal = addressDal;

            _logger = logger;
        }

        public async Task<Address> AddAddress(Address address)
        {
            _logger.Log(LogLevel.Debug, "Request Received for AddressBLL::AddAddress");

            return await _addressDal.AddAddress(address);
        }

        public async Task<IEnumerable<Address>> RetrieveAddressEnrollments(Guid studentId)
        {
            _logger.Log(LogLevel.Debug, "Request Received for AddressBLL::RetrieveAddressEnrollments");

            return await _addressDal.RetrieveAddressEnrollments(studentId);
        }
    }

}
