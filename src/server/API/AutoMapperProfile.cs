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
            .ForMember(dest => dest.UserName!, opt => opt.MapFrom(src => src.ApplicationUser!.UserName!))
            .ForMember(dest => dest.FirstName!, opt => opt.MapFrom(src => src.ApplicationUser!.FirstName!))
            .ForMember(dest => dest.LastName!, opt => opt.MapFrom(src => src.ApplicationUser!.LastName!))
            .ForMember(dest => dest.Email!, opt => opt.MapFrom(src => src.ApplicationUser!.Email!))
            .ForMember(dest => dest.PhoneNumber!, opt => opt.MapFrom(src => src.ApplicationUser!.PhoneNumber))
            .ForMember(dest => dest.Bilhete!, opt => opt.MapFrom(src => src.ApplicationUser!.Bilhete!))
            .ForMember(dest => dest.ImageId!, opt => opt.MapFrom(src => src.ApplicationUser!.ImageId!));
       
        CreateMap<ClientAddDTO, UserAddDTO>();
        CreateMap<ApplicationUser, ClientDTO>();

        CreateMap<ProfessionalAddDTO, ApplicationUser>();
        CreateMap<ProfessionalAddDTO, Professional>();
        CreateMap<Professional, ProfessionalDTO>()
            .ForMember(dest => dest.UserName!, opt => opt.MapFrom(src => src.ApplicationUser!.UserName!))
            .ForMember(dest => dest.FirstName!, opt => opt.MapFrom(src => src.ApplicationUser!.FirstName!))
            .ForMember(dest => dest.LastName!, opt => opt.MapFrom(src => src.ApplicationUser!.LastName!))
            .ForMember(dest => dest.Email!, opt => opt.MapFrom(src => src.ApplicationUser!.Email!))
            .ForMember(dest => dest.PhoneNumber!, opt => opt.MapFrom(src => src.ApplicationUser!.PhoneNumber))
            .ForMember(dest => dest.Bilhete!, opt => opt.MapFrom(src => src.ApplicationUser!.Bilhete!))
            .ForMember(dest => dest.ImageId!, opt => opt.MapFrom(src => src.ApplicationUser!.ImageId!));
       
        CreateMap<Professional, ProfessionalAddDTO>();
        CreateMap<Appointment, AppointmentDTO>();
        CreateMap<Appointment, AppointmentDTO>();
        CreateMap<Appointment, AppointmentAddDTO>();
        CreateMap<ServiceProfessionalAppointmentDTO, ServiceProfessionalAppointment>();
        CreateMap<ServiceProfessionalAppointment, ServiceProfessionalAppointmentDTO>();

        CreateMap<DateOnly, DateDTO>()
            .ForMember(dest => dest.year, opt => opt.MapFrom(src => src.Year))
            .ForMember(dest => dest.day, opt => opt.MapFrom(src => src.Day))
            .ForMember(dest => dest.month, opt => opt.MapFrom(src => src.Month))
            .ReverseMap();
    }
}