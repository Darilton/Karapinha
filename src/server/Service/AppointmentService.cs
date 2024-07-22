using AutoMapper;
using DTO;
using Model;
using Shared;

namespace Service;

public class AppointmentService : IAppointmentService
{
    private readonly IGenericRepository<Appointment> appointmentRepo;
    private readonly IMapper mapper;

    public AppointmentService(IMapper mapper, IGenericRepository<Appointment> appointmentRepo)
    {
        this.appointmentRepo = appointmentRepo;
        this.mapper = mapper;
    }
    public async Task<AppointmentDTO> AddAppointment(AppointmentAddDTO appointmentAddDTO, ICollection<ServiceProfessionalAppointment> serviceProfessionalAppointments)
    {
        Appointment appointment = await appointmentRepo.InsertAsync(new Appointment(){
            ClientId = appointmentAddDTO.ClientId,
            state = appointmentAddDTO.State,
        });

        return mapper.Map<AppointmentDTO>(appointment);
    }

    public async Task<AppointmentDTO> GetAppointment(int id)
    {
        Appointment ap = await appointmentRepo.GetByIdAsync(id);
        if(ap == null) return null!;

        return mapper.Map<AppointmentDTO>(ap);
    }

    public async Task<IEnumerable<AppointmentDTO>> GetAppointments()
    {
        return  mapper.Map<IEnumerable<AppointmentDTO>>(await appointmentRepo.GetAllAsync());
    }
}
