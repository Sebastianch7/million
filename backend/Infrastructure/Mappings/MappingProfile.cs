using AutoMapper;
using Domain.Entities;
using Application.DTOs;

namespace Infrastructure.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // 🔹 Property
            CreateMap<Property, PropertyDto>().ReverseMap();

            // 🔹 Owner
            CreateMap<Owner, OwnerDto>().ReverseMap();

            // 🔹 PropertyImage
            CreateMap<PropertyImage, PropertyImageDto>().ReverseMap();

            // 🔹 PropertyTrace
            CreateMap<PropertyTrace, PropertyTraceDto>().ReverseMap();
        }
    }
}
