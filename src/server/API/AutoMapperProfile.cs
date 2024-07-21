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

        CreateMap<UserAddDTO, ApplicationUser>();
        CreateMap<UserAddDTO, ClientAddDTO>();
        CreateMap<ApplicationUser, UserDTO>();

        CreateMap<ClientAddDTO, Client>();
        CreateMap<Client, ClientDTO>()
            .ForMember(dest => dest.UserName!, opt => opt.MapFrom(src => src.ApplicationUser.UserName))
            .ForMember(dest => dest.FirstName!, opt => opt.MapFrom(src => src.ApplicationUser.FirstName))
            .ForMember(dest => dest.LastName!, opt => opt.MapFrom(src => src.ApplicationUser.LastName))
            .ForMember(dest => dest.Email!, opt => opt.MapFrom(src => src.ApplicationUser.Email))
            .ForMember(dest => dest.PhoneNumber!, opt => opt.MapFrom(src => src.ApplicationUser.PhoneNumber))
            .ForMember(dest => dest.Bilhete!, opt => opt.MapFrom(src => src.ApplicationUser.Bilhete))
            .ForMember(dest => dest.ImageId!, opt => opt.MapFrom(src => src.ApplicationUser.ImageId));
        CreateMap<ClientAddDTO, UserAddDTO>();
        CreateMap<ApplicationUser, ClientDTO>();

        CreateMap<ProfessionalAddDTO, ApplicationUser>();
        CreateMap<Professional, ProfessionalDTO>();
    }
}
