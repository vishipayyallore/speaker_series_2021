using College.ApplicationCore.Entities;
using College.ApplicationCore.Interfaces;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace College.BLL
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

            var newAddress = await _addressDal.AddAddress(address);

            _logger.Log(LogLevel.Debug, "Returning the results from AddressBLL::AddAddress");

            return newAddress;
        }

    }

}
