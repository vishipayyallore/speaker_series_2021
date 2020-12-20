using College.ApplicationCore.Entities;
using College.ApplicationCore.Interfaces;
using College.ServerDAL.Persistence;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace College.ServerDAL
{

    public class AddressDAL : IAddressDAL
    {
        private readonly CollegeDbContext _collegeDbContext;
        private readonly ILogger<AddressDAL> _logger;

        public AddressDAL(CollegeDbContext collegeDbContext, ILogger<AddressDAL> logger)
        {
            _collegeDbContext = collegeDbContext;

            _logger = logger;
        }

        public async Task<Address> AddAddress(Address address)
        {
            _logger.Log(LogLevel.Debug, "Request Received for AddressDAL::AddAddress");

            _collegeDbContext.AddressBook.Add(address);

            await _collegeDbContext.SaveChangesAsync();

            _logger.Log(LogLevel.Debug, "Returning the results from AddressDAL::AddAddress");

            return address;
        }

        
    }

}
