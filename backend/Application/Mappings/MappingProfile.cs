using AutoMapper;
using Application.DTOs;
using Domain.Entities;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Owner
            CreateMap<Owner, OwnerDto>().ReverseMap();

            // Property
            CreateMap<Property, PropertyDto>().ReverseMap();

            // PropertyImage
            CreateMap<PropertyImage, PropertyImageDto>().ReverseMap();

            // PropertyTrace
            CreateMap<PropertyTrace, PropertyTraceDto>().ReverseMap();
        }
    }
}
