using AutoMapper;
using College.ApplicationCore.Entities;
using College.GrpcServer.Protos;

namespace College.GrpcServer.Mappings
{

    public class AddressBookAutoMappings : Profile
    {

        public AddressBookAutoMappings()
        {
            CreateMap<AddAddressRequest, Address>();
        }

    }

}
