using AutoMapper;
using DTO;
using Model;
using Shared;

namespace Service;

public class ServiceProfessionalAppointmentService : IServiceProfessionalAppointmentService
{
    private readonly IGenericRepository<ServiceProfessionalAppointment> repo;
    private readonly IGenericRepository<Professional> professionalRepo;
    private readonly IGenericRepository<Model.Service> serviceRepo;
    private readonly IGenericRepository<Model.WorkingHour> WorkingHourRepo;
    private readonly IMapper mapper;
    public ServiceProfessionalAppointmentService(IMapper mapper, IGenericRepository<Model.WorkingHour> WorkingHourRepo, IGenericRepository<Model.Service> serviceRepo, IGenericRepository<Professional> professionalRepo, IGenericRepository<ServiceProfessionalAppointment> repo)
    {
        this.repo = repo;
        this.professionalRepo = professionalRepo;
        this.serviceRepo = serviceRepo;
        this.mapper = mapper;
        this.WorkingHourRepo = WorkingHourRepo;
    }

    public async Task AddList(ICollection<ServiceProfessionalAppointment> saps, int appointmentId)
    {
        foreach (ServiceProfessionalAppointment item in saps)
        {
            item.AppointmentId = appointmentId;
           await repo.InsertAsync(item);
        }
    }

    public async Task<(ICollection<ServiceProfessionalAppointment>, string)> CreateProfessionalAppointmentAsync(ICollection<ServiceProfessionalAppointmentDTO> serviceProfessionalAppointments)
    {
        List<ServiceProfessionalAppointment> items = new List<ServiceProfessionalAppointment>();

        foreach (ServiceProfessionalAppointmentDTO spa in serviceProfessionalAppointments)
        {
            int index = 1;
            Professional professional = await professionalRepo.GetByIdAsync(spa.ProfessionalId);
            if(professional == null) return (null!, "item " + index + " in appointment: Professional with id " + spa.ProfessionalId + " not Found");

            Model.Service service = await serviceRepo.GetByIdAsync(spa.ServiceId);
            if(service == null) return (null!, "item " + index + " in appointment: Service with id " + spa.ServiceId);
            spa.Price = service.Price;
            Console.WriteLine(spa.Price);

            if(professional.CategoryId != service.CategoryId) return (null!, "item " + index + " in appointment: Professional with id " + spa.ProfessionalId + " Cannot serve Service with Id " + spa.ServiceId + " Because They are in diferent categories");

            WorkingHour wh = await WorkingHourRepo.GetByIdAsync(spa.WorkingHourId);
            if(wh == null) return (null!, "item " + index + " in appointment: There is no working hour with id" + spa.WorkingHourId);

            if(!professional.WorkHours!.Contains(wh)) return (null!, "item " + index + " in appointment: There is no working hour with id " + spa.WorkingHourId)!;
            
            items.Add(new ServiceProfessionalAppointment(){
                Professional = professional,
                WorkingHour = wh,
                Service = service,
                Price = spa.Price,
                date = new DateOnly(spa.date!.year, spa.date.month, spa.date.day),
            });
        }

        return (items, "");
    }
}
