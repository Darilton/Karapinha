using AutoMapper;
using DTO;
using Model;

namespace API;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile(){
        CreateMap<Model.Service, ServiceDTO>();
        CreateMap<ServiceDTO, Model.Service>();

        CreateMap<CategoryDTO, Category>();
        CreateMap<Category, CategoryDTO>();

        CreateMap<ServiceAddDTO, Model.Service>();

        CreateMap<WorkingHourDTO, WorkingHour>().ReverseMap();
        CreateMap<WorkingHour, WorkingHourDTO>().ReverseMap();
    }
}
