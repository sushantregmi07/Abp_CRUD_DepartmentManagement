using AutoMapper;
using Susant.BookStore.DTOs;
using Susant.BookStore.Entities;

namespace Susant.BookStore.Profiles;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // Department mappings
        //CreateMap<Department, DepartmentDto>();
        //CreateMap<CreateDepartmentDto, Department>();
        
        CreateMap<Department, DepartmentDto>()
            .ForMember(dest => dest.DepartmentTypeName, opt => opt.MapFrom(src => src.DepartmentType.Name));
        CreateMap<CreateDepartmentDto, Department>();

        // DepartmentType mappings
        CreateMap<DepartmentType, DepartmentTypeDto>();
        CreateMap<CreateDepartmentTypeDto, DepartmentType>();
    }
}