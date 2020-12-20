using College.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace College.ApplicationCore.Interfaces
{

    public interface IAddressBLL
    {
        Task<Address> AddAddress(Address address);

        Task<IEnumerable<Address>> RetrieveAddressEnrollments(Guid studentId);
    }

}
