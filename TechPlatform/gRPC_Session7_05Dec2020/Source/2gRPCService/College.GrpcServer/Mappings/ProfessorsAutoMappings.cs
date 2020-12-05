using AutoMapper;
using College.Core.Entities;
using College.GrpcServer.Protos;
using Google.Protobuf.Collections;
using Google.Protobuf.WellKnownTypes;
using System.Collections.Generic;

namespace College.GrpcServer.Mappings
{

    public class ProfessorsAutoMappings : Profile
    {
        public ProfessorsAutoMappings()
        {
            CreateMap<NewProfessorRequest, Professor>()
                .ForMember(destination => destination.Doj,
                                option => option.MapFrom(source => source.Doj.ToDateTime()));

            CreateMap<UpdateProfessorRequest, Professor>()
                .ForMember(destination => destination.Doj,
                                option => option.MapFrom(source => source.Doj.ToDateTime()));

            CreateMap<Professor, GetProfessorResponse>()
                .ForMember(destination => destination.Doj,
                            options => 
                            options.MapFrom(source => Timestamp.FromDateTime(source.Doj.ToUniversalTime())));
            
            //CreateMap<IEnumerable<Professor>, RepeatedField<GetProfessorResponse>>()
            //    .ForMember(destination => destination.Doj,
            //                options =>
            //                options.MapFrom(source => Timestamp.FromDateTime(source.Doj.ToUniversalTime())));
        }
    }

}
