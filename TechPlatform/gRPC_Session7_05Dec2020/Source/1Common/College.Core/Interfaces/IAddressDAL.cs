using College.ApplicationCore.Entities;
using System.Threading.Tasks;

namespace College.ApplicationCore.Interfaces
{

    public interface IAddressDAL
    {
        Task<Address> AddAddress(Address address);
    }

}
