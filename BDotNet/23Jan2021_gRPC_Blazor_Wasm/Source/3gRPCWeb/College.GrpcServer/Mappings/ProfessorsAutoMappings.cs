using AutoMapper;
using College.Core.Entities;
using College.GrpcServer.Protos;
using Google.Protobuf.WellKnownTypes;

namespace College.GrpcServer.Mappings
{

    public class ProfessorsAutoMappings : Profile
    {

        public ProfessorsAutoMappings()
        {
            CreateMap<Professor, GetProfessorResponse>()
                    .ForMember(destination => destination.Doj,
                                options =>
                                options.MapFrom(source => Timestamp.FromDateTime(source.Doj.ToUniversalTime())));
        }

    }

}
