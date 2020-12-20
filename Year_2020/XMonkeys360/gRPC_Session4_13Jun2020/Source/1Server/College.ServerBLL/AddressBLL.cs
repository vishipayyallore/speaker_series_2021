using College.ApplicationCore.Entities;
using College.ApplicationCore.Interfaces;
using Microsoft.Extensions.Logging;

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

        public Address AddAddress(Address address)
        {
            _logger.Log(LogLevel.Debug, "Request Received for AddressBLL::AddAddress");

            return _addressDal.AddAddress(address);
        }
    }

}
