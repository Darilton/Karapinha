using DTO;
using Model;

namespace Shared;

public interface IAppointmentService
{
    public Task<AppointmentDTO> GetAppointment(int id);
    public Task<IEnumerable<AppointmentDTO>> GetAppointments();
    public Task<AppointmentDTO> AddAppointment(AppointmentAddDTO appointmentAddDTO, ICollection<ServiceProfessionalAppointment> serviceProfessionalAppointments);
}
