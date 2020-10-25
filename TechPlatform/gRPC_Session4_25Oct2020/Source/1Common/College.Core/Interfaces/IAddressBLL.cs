using College.ApplicationCore.Entities;
using System.Threading.Tasks;

namespace College.ApplicationCore.Interfaces
{

    public interface IAddressBLL
    {
        Task<Address> AddAddress(Address address);
    }

}
