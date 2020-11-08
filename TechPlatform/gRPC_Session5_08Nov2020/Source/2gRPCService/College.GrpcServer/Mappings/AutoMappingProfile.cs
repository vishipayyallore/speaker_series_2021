using AutoMapper;
using College.Core.Entities;
using College.GrpcServer.Protos;
using Google.Protobuf.WellKnownTypes;

namespace College.GrpcServer.Mappings
{

    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<NewProfessorRequest, Professor>()
                .ForMember(destination => destination.Doj,
                                option => option.MapFrom(source => source.Doj.ToDateTime()));

            CreateMap<Professor, GetProfessorResponse>()
                .ForMember(destination => destination.Doj,
                            options => 
                            options.MapFrom(source => Timestamp.FromDateTime(source.Doj.ToUniversalTime())));
        }
    }

}
