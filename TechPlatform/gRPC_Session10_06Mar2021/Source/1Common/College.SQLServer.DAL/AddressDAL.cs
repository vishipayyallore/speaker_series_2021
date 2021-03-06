using College.ApplicationCore.Entities;
using College.ApplicationCore.Interfaces;
using College.SQLServer.DAL.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace College.SQLServer.DAL
{

    public class AddressDAL : IAddressDAL
    {
        private readonly CollegeSqlDbContext _collegeDbContext;
        private readonly ILogger<AddressDAL> _logger;

        public AddressDAL(CollegeSqlDbContext collegeDbContext, ILogger<AddressDAL> logger)
        {
            _collegeDbContext = collegeDbContext ?? throw new ArgumentNullException(nameof(collegeDbContext));
            
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Address> AddAddress(Address address)
        {
            _logger.Log(LogLevel.Debug, "Request Received for AddressDAL::AddAddress");

            _collegeDbContext.AddressBook.Add(address);

            await _collegeDbContext.SaveChangesAsync();

            _logger.Log(LogLevel.Debug, "Returning the results from AddressDAL::AddAddress");

            return address;
        }

        public async Task<IEnumerable<Address>> RetrieveAddressEnrollments(Guid studentId)
        {
            _logger.Log(LogLevel.Debug, "Request Received for AddressDAL::RetrieveAddressEnrollments");

            IEnumerable<Address> studentEntrollments = await _collegeDbContext.AddressBook
                                                            .Where(record => record.StudentId == studentId)
                                                            .ToListAsync()
                                                            .ConfigureAwait(false);

            _logger.Log(LogLevel.Debug, "Returning the results from AddressDAL::RetrieveAddressEnrollments");

            return studentEntrollments;
        }
    }

}
